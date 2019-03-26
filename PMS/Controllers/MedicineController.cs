using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.Cache;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    public class MedicineController : BaseController
    {
        public MedicineController(ICacheContext cacheContext, IUserService userService) : base(cacheContext, userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}