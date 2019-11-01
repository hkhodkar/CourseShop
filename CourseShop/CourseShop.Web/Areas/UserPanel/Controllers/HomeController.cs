using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CourseShop.Web.Areas.UserPanel.Controllers
{
    /// <summary>
    /// Author : hatef khodkar
    /// Created Date : 1/10/2019
    /// Last Update : 1/11/2019
    /// </summary>
    /// <returns></returns>

    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = _userService.GetUserInformation(User.Identity.Name);
            return await Task.Run(() => View(user));
        }

        #region EditProfile

        [HttpGet]
        [Route("UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            var user = _userService.GetUserInfForEdit(User.Identity.Name);
            return await Task.Run(() => View(user));
        }

        [HttpPost]
        [Route("UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfile(EditProfileViewModel viewModel)
        {
            if (!ModelState.IsValid) return await Task.Run(() => View(viewModel));

            _userService.EditProfile(User.Identity.Name, viewModel);
            return await Task.Run(() => Redirect("/userpanel"));
        }

        #endregion

        #region ChangePassword
        [HttpGet]
        [Route("UserPanel/ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        [Route("UserPanel/ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePass)
        {
            if (!ModelState.IsValid) return await Task.Run(() => View(changePass));

            var chPass = _userService.ChangePassword(User.Identity.Name, changePass);

            if (chPass == false)
            {
                ViewBag.IsSuccess = false;
                return await Task.Run(() => View(changePass));
            }
            ViewBag.IsSuccess = true;
            return await Task.Run(() => View());
        }
        #endregion

    }

}