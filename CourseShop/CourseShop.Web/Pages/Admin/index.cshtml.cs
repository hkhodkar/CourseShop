using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages
{
    [PermissionChecker(1)]
    public class AdminModel : PageModel
    {


        public void OnGet()
        {
        }
    }
}