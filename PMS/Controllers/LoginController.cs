using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.ViewModel;
using PMS.Services;

namespace PMS.Controllers
{
    public class LoginController : Controller
    {
        private UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var result = _userService.UserLogin(model);
            return Json(result);
        }
    }
}