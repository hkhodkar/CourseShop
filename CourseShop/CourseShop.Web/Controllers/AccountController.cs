using CourseShop.Core.Convertors;
using CourseShop.Core.DTO;
using CourseShop.Core.Generators;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.Core.Senders;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseShop.Web.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Author : hatef khodkar
        /// Created Date : 21/10/2019
        /// Last Update : 21/10/2019
        /// </summary>
        /// <returns></returns>

        private readonly IViewRenderService _renderView;
        private readonly IUserService _userService;
        public AccountController(
            IViewRenderService renderView,
            IUserService userService)
        {
            _renderView = renderView;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Register")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return await Task.Run(() => View());
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() => View());

            if (_userService.EmailIsExist(viewModel.Email))
            {
                ViewBag.EmailIsTaken = true;
                return await Task.Run(() => View(viewModel));
            }

            if (_userService.UserIsExist(viewModel.Username))
            {
                ViewBag.UserIsTaken = true;
                return await Task.Run(() => View(viewModel));
            }

            User user = new User
            {
                Username = viewModel.Username,
                Email = FixedText.FixedEmail(viewModel.Email),
                ActivateCode = NameGenerator.GenerateUniqCode(),
                AvatarName = "default.jpg",
                IsActive = false,
                PasswordHash = PasswordHelper.EncodePasswordMd5(viewModel.Password),
                RegisterDate = DateTime.Now
            };

            _userService.AddUser(user);

            #region Send Email
            string body = _renderView.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(viewModel.Email, "فعال سازی اکانت", body);

            #endregion

            ViewBag.IsSuccess = true;

            return await Task.Run(() => View(viewModel));
        }
    }
}