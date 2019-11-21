using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.DTOs;
using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Roles
{
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




        public  void OnGet()
        {
            PermissionsList =  _permissionService.PermissionList();
        }

        public IActionResult OnPost(List<int> permissionIdList)
        {
            var roleId =_roleService.AddRole(Role);

            foreach(var permissionId in permissionIdList)
            {
                _permissionService.AddRolePermission(roleId, permissionId);
            }

            return RedirectToPage("index");
        }
    }
}