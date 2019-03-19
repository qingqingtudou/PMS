using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Linq;

namespace PMS.Services.Implements
{
    public class UserService : BaseRepository<SysUser>, IUserService
    {
        public UserService(PMSDbContext context) : base(context)
        {
        }

        public OperateResult<SysUser> UserLogin(LoginModel model)
        {
            var query = _context.SysUsers.Where(f => f.Account == model.Account && f.Password == model.Password && f.IsDelete == false && f.Status == (int)EDataStatus.valid);
            var user = query.FirstOrDefault();
            OperateResult<SysUser> result = new OperateResult<SysUser>();

            if (user == null)
            {
                result.Code = (int)EResponse.NotFound;
                result.Message = "用户名或密码错误";
                return result;
            }
            result.Code = (int)EResponse.Ok;
            result.Message = "登录成功";
            result.Payload = user;
            return result;
        }
    }
}
