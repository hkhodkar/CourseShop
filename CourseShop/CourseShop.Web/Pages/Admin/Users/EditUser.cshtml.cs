using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Convertors;
using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Users
{
    [PermissionChecker(4)]
    public class EditUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public EditUserModel(
            IUserService userService,
            IRoleService roleService
            )
        {
            _userService = userService;
            _roleService = roleService;
        }



        [BindProperty]
        public UserForAdminViewModel UserViewModel { get; set; }

        public List<Role> RolesList { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            RolesList = _roleService.GetRolesList();

            UserViewModel =await _userService.GetUserForEditMode(id);

            if (UserViewModel == null)
                return await Task.Run(()=> NotFound());


            return await Task.Run(() => Page());

        }

        public async Task<IActionResult> OnPost(List<int> Roles)
        {

            if (!ModelState.IsValid)
            {
                RolesList = _roleService.GetRolesList();
                return await Task.Run(() => Page());
            }

            var userid = await _userService.EditUserAdminPanel(UserViewModel);

           _roleService.UpdateUserRoles(userid, Roles);

            return  Redirect("/admin/users");
        }
    }
}