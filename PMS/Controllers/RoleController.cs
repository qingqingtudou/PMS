using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure;
using PMS.Infrastructure.Cache;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class RoleController : BaseController
    {
        public RoleController(ICacheContext cacheContext, IUserService userService, IRoleService roleService) : base(cacheContext, userService)
        {
            _roleService = roleService;
        }

        private IRoleService _roleService;

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Assign()
        {
            return View();
        }

        public string GetUserRoles()
        {
            return JsonHelper.Instance.Serialize(_roleService.GetUserRoles((int)CurrentUser.RoleId));
        }
    }
}