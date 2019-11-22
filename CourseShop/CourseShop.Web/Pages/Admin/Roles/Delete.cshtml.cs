using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CourseShop.Web.Pages.Admin.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly IRoleService _roleService;

        public DeleteModel(
             IRoleService roleService
            )
        {
            _roleService = roleService;
        }

        [BindProperty]
        public IList<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _roleService.GetDeleteRoleList();
        }

        public void OnGetDelete(int id)
        {
            _roleService.DeleteRole(id);
        }

        public void OnGetRestore(int id)
        {
            _roleService.RestoreRole(id);
        }
    }
}