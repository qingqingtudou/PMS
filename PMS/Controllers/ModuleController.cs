using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure;
using PMS.Infrastructure.Cache;
using PMS.Infrastructure.Model;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class ModuleController : BaseController
    {
        private IModuleService _moduleService;

        public ModuleController(ICacheContext cacheContext, IUserService userService, IModuleService moduleService) : base(cacheContext, userService)
        {
            _moduleService = moduleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string GetModulesTree()
        {
            return JsonHelper.Instance.Serialize(_moduleService.GetRoleModules(CurrentUser.RoleId ?? 0).GenerateTree(u => u.Id, u => u.ParentId));
        }

        public string GetMenuElements(string modulecode)
        {
            List<ModuleElement> list = null;
            switch (modulecode)
            {
                case "User":
                    list = _moduleService.GetUserMenus();
                    break;
                case "Org":
                    list = _moduleService.GetOrgMenus();
                    break;
                default:
                    break;
            }
            return JsonHelper.Instance.Serialize(list);
        }
    }
}