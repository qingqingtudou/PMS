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

        public OperateResult AddMedicine(MedicineView view,string account)
        {
            Medicine medicine = new Medicine()
            {
                Name = view.Name,
                Code = view.Code,
                CreateTime = DateTime.Now,
                Creator = account,
                DateinProduced = view.DateinProduced,
                EndTime = view.EndTime,
                ExpirationDate = view.ExpirationDate,
                IsDelete = false,
                Status = (int)EDataStatus.valid
            };
            medicine.Inventory.IsDelete = false;
            medicine.Inventory.Status = (int)EDataStatus.valid;
            medicine.Inventory.Total = view.InventoryNum ?? 0;
            medicine.Inventory.Batch = view.Batch;
            medicine.Inventory.CreateTime = DateTime.Now;
            medicine.Inventory.Creator = account;
            _context.Medicines.Add(medicine);

            try
            {
                _context.SaveChanges();
                return new OperateResult();
            }
            catch (Exception e)
            {
                return new OperateResult() { Code = 500,Message = e.Message};
            }

        }

        public OperateResult DeleteMedicine(int id, string account)
        {
            var medicine = _context.Medicines.Find(id);
            medicine.Status = (int)EDataStatus.Deleted;
            medicine.IsDelete = true;
            medicine.Inventory.IsDelete = true;
            medicine.Inventory.Status = (int)EDataStatus.Deleted;
            try
            {
                _context.SaveChanges();
                return new OperateResult();
            }
            catch (Exception e)
            {
                return new OperateResult() { Code = 500, Message = e.Message };
            }
        }

        public OperatePageResult GetMedicineListByPage(PageSize pageSize)
        {
            var query = _context.Medicines.AsNoTracking().Where(w => w.Status == (int)EDataStatus.valid && w.IsDelete == false).Select(s =>new MedicineView()
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

        public OperateResult UpdateMedicine(MedicineView view, string account)
        {
            if(view.Id < 1)
            {
                return new OperateResult() { Code = 500, Message = "选定的药品无效，请重新选择" };
            }
            var medicine = _context.Medicines.Find(view.Id);
            medicine.Name = view.Name;
            medicine.Code = view.Code;
            medicine.UpdateTime = DateTime.Now;
            medicine.Updator = account;
            medicine.DateinProduced = view.DateinProduced;
            medicine.EndTime = view.EndTime;
            medicine.ExpirationDate = view.ExpirationDate;
            medicine.Inventory.Total = view.InventoryNum ?? medicine.Inventory.Total;
            try
            {
                _context.SaveChanges();
                return new OperateResult();
            }
            catch (Exception e)
            {
                return new OperateResult() { Code = 500, Message = e.Message };
            }
        }
    }
}
