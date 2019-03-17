using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services
{
    public class UserService : BaseService<SysUser>
    {
        public UserService(IUnitWork unitWork, IRepository<SysUser> repository) : base(unitWork, repository)
        {
        }

        public Response<LoginResult> UserLogin(LoginModel model)
        {
            var user = Repository.FindSingle(f => f.Account == model.Account && f.Password == model.Password && f.IsDelete == false && f.Status == (int)EDataStatus.valid);

            Response<LoginResult> result = new Response<LoginResult>();

            if (user == null)
            {
                result.Code = (int)EResponse.NotFound;
                result.Message = "用户名或密码错误";
                return result;
            }
            result.Code = (int)EResponse.Ok;
            result.Message = "登录成功";
            result.Payload = new LoginResult()
            {
                Name = user.Name
            };
            return result;
        }
    }
}
