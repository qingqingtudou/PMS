using PMS.Infrastructure.Response;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Interfaces
{
    public interface IRoleService:IRepository<Role>
    {
        /// <summary>
        /// 获取用户可见的角色列表
        /// </summary>
        /// <param name="userRole">用户角色id</param>
        /// <returns></returns>
        List<RoleView> GetUserRoles(int userRole);
    }
}
