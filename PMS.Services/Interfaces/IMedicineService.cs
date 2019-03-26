using PMS.Infrastructure.Model;
using PMS.Infrastructure.Response;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Interfaces
{
    /// <summary>
    /// 药品信息服务接口
    /// </summary>
    public interface IMedicineService:IRepository<Medicine>
    {
        OperatePageResult GetMedicineListByPage(PageSize pageSize);

        OperateResult AddMedicine(MedicineView view, string account);
    }
}
