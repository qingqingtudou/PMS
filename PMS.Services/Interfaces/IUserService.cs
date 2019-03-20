using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Services.Interfaces
{
    public interface IUserService: IRepository<SysUser>
    {
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="model">用户登录模型</param>
        /// <returns></returns>
        OperateResult<SysUser> UserLogin(LoginModel model);

        /// <summary>
        /// 通过用户Id获取用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SysUser GetSysUserById(int Id);
    }
}
