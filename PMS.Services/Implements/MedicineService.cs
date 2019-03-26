using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Model;
using PMS.Infrastructure.Response;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public OperatePageResult GetMedicineListByPage(PageSize pageSize)
        {
            var query = _context.Medicines.AsNoTracking().Where(w => w.Status == (int)EDataStatus.valid && w.IsDelete == false).Select(s =>new MidicineView()
            {
                Id = s.Id,
                Code = s.Code,
                DateinProduced = s.DateinProduced,
                EndTime = s.EndTime,
                ExpirationDate = s.ExpirationDate,
                Name = s.Name,
                InventoryNum = s.Inventory.Total
            });
            if (!string.IsNullOrEmpty(pageSize.key))
            {
                query = query.Where(w => w.Name.Contains(pageSize.key));
            }

            OperatePageResult result = new OperatePageResult
            {
                count = query.Count(),
                data = query.OrderBy(o => o.Id).Skip((pageSize.page - 1) * pageSize.limit).Take(pageSize.limit).ToList()
            };

            return result;
        }
    }
}
