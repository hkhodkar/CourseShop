using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseShop.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class WalletController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;

        public WalletController(
            IWalletService walletService,
            IUserService userService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userService.GetUserIdByUserName(User.Identity.Name);
            var wallets = _walletService.GetUserWallet(userId);
            ViewBag.userWallets = wallets;
            ViewBag.Balance = _walletService.WallateBalance(userId);
            
            return await Task.Run(()=>View());
        }


        [Route("UserPanel/Wallet")]
        [HttpPost]
        public async Task<ActionResult> Index(CaharegeWalletViewModel charge)
        {
            var userId = _userService.GetUserIdByUserName(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                var wallets = _walletService.GetUserWallet(userId);
                ViewBag.userWallets = wallets;
                ViewBag.Balance = _walletService.WallateBalance(userId);

                return await Task.Run(() => View());
            }

            var wallet = new Wallet()
            {
                Amount = charge.Amount,
                CreateDate = DateTime.Now,
                Description = "شارژ کیف پول",
                IsPay = false,
                TypeId = 1,
                UserId = userId
            };

            int walletId = _walletService.ChargeWallet(wallet);

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", "https://localhost:44361/OnlinePayment/" + walletId, "Info@topLearn.Com", "09197070750");

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion


            return null;
        }

    }
}

