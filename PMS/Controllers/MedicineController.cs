using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure;
using PMS.Infrastructure.Cache;
using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Model;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    /// <summary>
    /// 药品信息 接口
    /// </summary>
    public class MedicineController : BaseController
    {
        public MedicineController(ICacheContext cacheContext, IUserService userService, IMedicineService medicineService) : base(cacheContext, userService)
        {
            _medicineService = medicineService;
        }

        private IMedicineService _medicineService;

        public IActionResult Index()
        {
            return View();
        }

        public string GetList(PageSize pageSize)
        {
            return JsonHelper.Instance.Serialize(_medicineService.GetMedicineListByPage(pageSize));
        }
    }
}