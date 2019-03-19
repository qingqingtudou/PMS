using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.ViewModel;
using PMS.Services;
using PMS.Services.Implements;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var result = _userService.UserLogin(model);
            //if (result.Code == 200)
            //{
            //    Response.Cookies.Append("Token", result.Payload.Token);
            //}
            return Json(result);
        }
    }
}