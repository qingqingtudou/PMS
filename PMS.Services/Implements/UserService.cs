using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System.Linq;

namespace PMS.Services.Implements
{
    public class UserService : BaseRepository<SysUser>, IUserService
    {
        public UserService(PMSDbContext context)
        {
            db = context;
        }

        public Response<LoginResult> UserLogin(LoginModel model)
        {
            var user = db.SysUsers.Where(f => f.Account == model.Account && f.Password == model.Password && f.IsDelete == false && f.Status == (int)EDataStatus.valid).FirstOrDefault();

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
