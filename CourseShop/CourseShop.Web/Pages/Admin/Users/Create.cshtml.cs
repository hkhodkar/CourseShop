using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public List<Role> RolesList { get; set; }
        public void OnGet()
        {
            RolesList = _roleService.GetRolesList();
        }
    }
}