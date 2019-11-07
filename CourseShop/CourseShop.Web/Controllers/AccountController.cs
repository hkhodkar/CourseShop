using CourseShop.Core.Convertors;
using CourseShop.Core.DTOs;
using CourseShop.Core.Generators;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.Core.Senders;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseShop.Web.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Author : hatef khodkar
        /// Created Date : 21/10/2019
        /// Last Update : 1/11/2019
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


        #region Login
        [Route("Login")]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return await Task.Run(() => View());
        }


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if(!ModelState.IsValid) return await Task.Run(() => View(viewModel));

            var user = _userService.Login(viewModel);
            if (user != null)
            {
                if (user.IsActive == true)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Email,user.Email)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = viewModel.RememberMe
                    };
                    await HttpContext.SignInAsync(principal, properties);
                    ViewBag.IsSuccess = true;
                    return await Task.Run(() => View());
                }
                else
                {
                    ViewBag.IsNotActivate = true;
                    return await Task.Run(() => View(viewModel));
                }

            }
            else
            {
                ViewBag.IsSuccess = false;
                return await Task.Run(() => View(viewModel));
            }
        }

        #endregion

        #region Register
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
                return await Task.Run(() => View(viewModel));

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

            return await Task.Run(() => View("SuccessfullRegistration", viewModel));
        }

        public IActionResult ActiveAccount(string Id)
        {
            var user = _userService.UserByActivateCode(Id);
            if (user == null)
            {
                ViewBag.IsSuccess = false;
                return View();
            }
            else
            {
                ViewBag.IsSuccess = true;
                user.IsActive = true;
                user.ActivateCode = NameGenerator.GenerateUniqCode();
                _userService.UpdateUser(user);

                return View(user);
            }


        }
        #endregion

        #region logout
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return await Task.Run(() => Redirect("/"));
        }

        #endregion

        #region ForgotPassword

        [HttpGet]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgottenPassword()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgottenPassword(ForgotPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() => View(viewModel));

            var email = FixedText.FixedEmail(viewModel.Email);
            var user = _userService.GetUserByEmail(email);
            if (user != null)
            {
                var body = _renderView.RenderToStringAsync("_ForgotEmail", user);
                SendEmail.Send(user.Email, "بازیابی کلمه عبور", body);
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsSuccess = false;
            }
            return await Task.Run(() => View(viewModel));
        }

        [HttpGet]
        public async Task<IActionResult> RessetPassword(string id)
        {
            var user = _userService.UserByActivateCode(id);
            if (user == null) return View("ExpiredLink");

            return await Task.Run(() => View(
                new RessetPasswordViewModel
                {
                    ActivateCode = id
                }
                ));
        }


        [HttpPost]
        public async Task<IActionResult> RessetPassword(RessetPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() => View(viewModel));

            var user = _userService.UserByActivateCode(viewModel.ActivateCode);
            if (user == null) return NotFound();

            var passHash = PasswordHelper.EncodePasswordMd5(viewModel.Password);

            user.PasswordHash = passHash;
            user.ActivateCode = NameGenerator.GenerateUniqCode();
            _userService.UpdateUser(user);
            ViewBag.IsSuccess = true;
            return await Task.Run(() => View());
        }
        #endregion

    }
}