using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
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


        public void OnGet(int id)
        {
            _roleService.DeleteRole(id);

        }


        public void OnGetRestore(int id)
        {
            _roleService.RestoreRole(id);
        }
    }
}