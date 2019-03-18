using PMS.Infrastructure.ViewModel;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public List<ModuleView> GetRoleModules()
        {
            throw new NotImplementedException();
        }
    }
}
