using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure;
using PMS.Infrastructure.Cache;
using PMS.Infrastructure.Model;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class UserManagerController : BaseController
    {
        public UserManagerController(ICacheContext cacheContext, IUserService userService) : base(cacheContext, userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Load(QueryUserReq request)
        {
            request.fullpath = CurrentUser.OrgFullPath;
            return JsonHelper.Instance.Serialize(_userService.GetUserList(request));
        }
    }
}