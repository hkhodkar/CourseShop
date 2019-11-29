using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Interfaces;
using CourseShop.Core.Security;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Users
{
    [PermissionChecker(5)]
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public IEnumerable<User> UsersForAdmin { get; set; }

        public void OnGet()
        {
            UsersForAdmin = _userService.GetDeleteUsersList();
        }

        public void OnGetDelete(int id)
        {
            _userService.DeleteUser(id);
        }

        public void OnGetRestore(int id)
        {
            _userService.RestoreUser(id);
        }

        public void OnDelete(int id)
        {
            _userService.DeleteUser(id);
        }


    }
}