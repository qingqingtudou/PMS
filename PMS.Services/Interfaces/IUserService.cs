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
        SysUser GetByStr(string username, string pwd);
        OperateResult<LoginResult> UserLogin(LoginModel model);

        /// <summary>
        /// 检验token是否有效
        /// </summary>
        /// <param name="token">token值</param>
        /// <param name="otherInfo"></param>
        /// <returns></returns>
        //bool CheckLogin(string token = "", string otherInfo = "");
    }
}
