using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.Cache;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ICacheContext cacheContext, IUserService userService) : base(cacheContext, userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUserName()
        {
            //var user = _cacheContext.Get<SysUser>(Account);
            return Json(CurrentUser.Name);
        }
    }
}