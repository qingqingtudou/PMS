using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.Cache;
using PMS.Infrastructure.Model;
using PMS.Models;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICacheContext cacheContext, IUserService userService)
        {
            _cacheContext = cacheContext;
            _userService = userService;
        }

        private ICacheContext _cacheContext;
        private IUserService _userService;

        public IActionResult Index()
        {
            var curentUser = _cacheContext.Get<UserModel>(Account);
            if(curentUser == null)
            {
                var user = _userService.GetSysUserById(UserId);
                _cacheContext.Set(Account, user, DateTime.Now.AddDays(1));
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
