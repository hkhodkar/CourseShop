using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CourseShop.Web.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly IRoleService _roleService;
        public CreateModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public CreateUserForAdmin CreateUserViewModel { get; set; }
        public List<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _roleService.GetRolesList();
        }

        public IActionResult OnPost(List<int> Roles)
        {

            return Redirect("/admin/users");
        }
    }
}