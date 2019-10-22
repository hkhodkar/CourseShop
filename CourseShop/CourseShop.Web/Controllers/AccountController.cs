using CourseShop.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseShop.Web.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Author : hatef khodkar
        /// Created Date : 21/10/2019
        /// Last Update : 21/10/2019
        /// </summary>
        /// <returns></returns>


        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Register")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return await Task.Run(() => View());
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return await Task.Run(() => View());

            return await Task.Run(() => View());
        }
    }
}