using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Roles
{
    public class CreateModel : PageModel
    {

        public RoleForAdminViewModel RoleViewModel { get; set; }

        public void OnGet()
        {

        }
    }
}