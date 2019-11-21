using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CourseShop.Web.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public List<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _roleService.GetRolesList();
        }
    }
}