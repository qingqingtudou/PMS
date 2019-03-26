using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Implements
{
    /// <summary>
    /// 药品信息服务
    /// </summary>
    public class MedicineService : BaseRepository<Medicine>, IMedicineService
    {
        public MedicineService(PMSDbContext context) : base(context)
        {
        }


    }
}
