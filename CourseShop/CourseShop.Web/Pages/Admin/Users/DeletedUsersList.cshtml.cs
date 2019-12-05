using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CourseShop.Web.Pages.Admin.Users
{
    public class DeletedUsersListModel : PageModel
    {
        private readonly IUserService _userService;


        public DeletedUsersListModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public IList<User> DeletedUsersList { get; set; }

        public void OnGet()
        {
            DeletedUsersList = _userService.GetDeleteUsersList();
        }
    }
}