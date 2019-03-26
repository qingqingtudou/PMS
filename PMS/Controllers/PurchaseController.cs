using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.Cache;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    /// <summary>
    /// 采购管理
    /// </summary>
    public class PurchaseController : BaseController
    {
        public PurchaseController(ICacheContext cacheContext, IUserService userService) : base(cacheContext, userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}