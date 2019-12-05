using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Roles
{
    [PermissionChecker(9)]
    public class DeletedRolesListModel : PageModel
    {

        private readonly IRoleService _roleService;

        public DeletedRolesListModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public IList<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _roleService.GetDeleteRoleList();
        }
    }
}