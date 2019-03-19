using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.ViewModel;
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
    /// 功能模块服务
    /// </summary>
    public class ModuleService : BaseRepository<Module>, IModuleService
    {
        public ModuleService(PMSDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 获取角色功能模块
        /// </summary>
        /// <returns></returns>
        public List<ModuleView> GetRoleModules(int roleId)
        {
            var roleModuleIds = _context.RoleModules.AsNoTracking().Where(w => w.RoleId == roleId).Select(s => s.ModuleId).ToList();
            var modules = _context.Modules.AsNoTracking().Where(w => roleModuleIds.Contains(w.Id)).Select(s => new ModuleView()
            {
                Id = s.Id,
                Name = s.Name,
                CascadeId = s.CascadeId,
                Code = s.Code,
                IconName = s.IconName,
                Url = s.Url,
                ParentId = s.ParentId,
                ParentName = s.ParentName,
            }).ToList();
            return modules;
        }
    }
}
