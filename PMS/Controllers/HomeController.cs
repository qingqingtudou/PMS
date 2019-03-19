using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Models;

namespace PMS.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var userName = User;
            var t = HttpContext.User.Claims;
            var claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
            var claimsPrincipal = claimIdentity.Claims as List<Claim>;
            
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
