using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CourseShop.Web.Pages.Admin.Roles
{
    [PermissionChecker(8)]
    public class EditModel : PageModel
    {
        private readonly IPermissionService _permissionService;
        private readonly IRoleService _roleService;

        public EditModel(
            IPermissionService permissionService,
            IRoleService roleService)
        {
            _permissionService = permissionService;
            _roleService = roleService;

        }


        [BindProperty]
        public Role Role { get; set; }
        public List<Permission> PermissionsList { get; set; }
        public List<int> SelectedPermission { get; set; }


        public IActionResult OnGet(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            Role = role;
            PermissionsList = _permissionService.PermissionList();
            SelectedPermission = _permissionService.GetRolesPermission(id);

            return Page();
        }

        public IActionResult OnPost(List<int> permissionIdList)
        {
            _permissionService.EditRolePermission(Role.RoleId, permissionIdList);

            return RedirectToPage("index");
        }
    }
}