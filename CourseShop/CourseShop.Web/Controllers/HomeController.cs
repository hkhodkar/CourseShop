using CourseShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseShop.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Author : hatef khodkar
        /// Created Date : 21/10/2019
        /// Last Update : 21/10/2019
        /// </summary>
        /// <returns></returns>
        /// 

        private readonly IUserService _userService;
        private readonly IWalletService _walletService;

        public HomeController(
            IUserService userService,
            IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("OnlinePayment/{id}")]
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = _walletService.GetWalletById(id);

                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.IsPay = true;
                    _walletService.UpdateWallet(wallet);
                }

            }

            return View();
        }


    }
}