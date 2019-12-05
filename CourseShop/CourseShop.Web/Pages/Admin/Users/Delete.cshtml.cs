using CourseShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Users
{
    public class DeleteModel : PageModel
    {

        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }


        public void OnGet(int id)
        {
            _userService.DeleteUser(id);
        }

        public void OnGetRestore(int id)
        {
            _userService.RestoreUser(id);
        }
    }
}