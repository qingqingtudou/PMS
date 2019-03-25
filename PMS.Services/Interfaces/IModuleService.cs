using PMS.Infrastructure.ViewModel;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System.Collections.Generic;

namespace PMS.Services.Interfaces
{
    /// <summary>
    /// 功能模块服务接口
    /// </summary>
    public interface IModuleService: IRepository<Module>
    {
        /// <summary>
        /// 获取角色功能模块
        /// </summary>
        /// <returns></returns>
        List<ModuleView> GetRoleModules(int roleId);

        List<ModuleElement> GetUserMenus();

        List<ModuleElement> GetOrgMenus();
    }
}
