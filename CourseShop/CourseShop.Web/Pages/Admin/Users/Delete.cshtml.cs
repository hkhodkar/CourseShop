using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
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


    }
}