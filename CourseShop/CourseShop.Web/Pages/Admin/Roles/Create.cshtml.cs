using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CourseShop.Web.Pages.Admin.Roles
{
    [PermissionChecker(7)]
    public class CreateModel : PageModel
    {

        private readonly IPermissionService _permissionService;
        private readonly IRoleService _roleService;

        public CreateModel(
            IPermissionService permissionService,
            IRoleService roleService
            )
        {
            _permissionService = permissionService;
            _roleService = roleService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public List<Permission> PermissionsList { get; set; }




        public void OnGet()
        {
            PermissionsList = _permissionService.PermissionList();
        }

        public IActionResult OnPost(List<int> permissionIdList)
        {
            var roleId = _roleService.AddRole(Role);

            {
                _permissionService.AddRolePermission(roleId, permissionIdList);

                return RedirectToPage("index");
            }
        }
    }
}