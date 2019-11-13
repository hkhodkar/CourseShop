using CourseShop.Core.Convertors;
using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseShop.Web.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public CreateModel(
            IRoleService roleService,
            IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [BindProperty]
        public CreateUserForAdminViewModel CreateUserViewModel { get; set; }
        public List<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _roleService.GetRolesList();
        }

        public async Task<IActionResult> OnPost(List<int> Roles)
        {
            RolesList = _roleService.GetRolesList();
            if (!ModelState.IsValid)
            {
                return await Task.Run(() => Page());
            }

            var fixedEmail = FixedText.FixedEmail(CreateUserViewModel.Email);
            if (_userService.EmailIsExist(fixedEmail))
            {
                ModelState.AddModelError("CreateUserViewModel.Email", "کاربری با ایمیل وارد شده قبلا در سیستم ثبت گردیده است");
                return await Task.Run(() => Page());
            }

            var userId = await _userService.AddUserInAdminPanel(CreateUserViewModel);

            foreach (var roleId in Roles)
            {
                _roleService.AddUserRole(userId, roleId);
            }
            return await Task.Run(() => Redirect("/admin/users"));
        }
    }
}