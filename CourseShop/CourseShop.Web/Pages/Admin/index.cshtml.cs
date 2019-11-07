using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {


        public void OnGet()
        {
        }
    }
}