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
    public class OrgController : BaseController
    {
        public OrgController(ICacheContext cacheContext, IUserService userService, IOrgService orgService) : base(cacheContext, userService)
        {
            _orgService = orgService;
        }

        private IOrgService _orgService;

        public IActionResult Index()
        {
            return View();
        }

        public string GetOrgs()
        {
            return JsonHelper.Instance.Serialize(_orgService.GetOrgs(CurrentUser.OrgFullPath));
        }

        public string GetOrgTree()
        {
            return JsonHelper.Instance.Serialize(_orgService.GetTreeModels(CurrentUser.OrgFullPath, CurrentUser.OrgId ?? 0));
        }
    }
}