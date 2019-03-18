using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Cache;
using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Auth;
using PMS.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Services.Implements
{
    public class UserService : BaseRepository<SysUser>, IUserService
    {
        public UserService(PMSDbContext context) : base(context)
        {
        }

        //private IHttpContextAccessor _httpContextAccessor;
        //private ICacheContext _cacheContext;
        //public UserService(PMSDbContext context)
        //{
        //    db = context;
        //}

        public OperateResult<LoginResult> UserLogin(LoginModel model)
        {
            var query = _context.SysUsers.Where(f => f.Account == model.Account && f.Password == model.Password && f.IsDelete == false && f.Status == (int)EDataStatus.valid);
            var user = query.FirstOrDefault();
            OperateResult<LoginResult> result = new OperateResult<LoginResult>();

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
                Id = user.Id,
                Account = user.Account,
                Name = user.Name,
                Token = Guid.NewGuid().ToString().GetHashCode().ToString("x")
            };
            return result;
        }

        //public bool CheckLogin(string token = "", string otherInfo = "")
        //{
        //    if (string.IsNullOrEmpty(token))
        //    {
        //        token = GetToken();
        //    }

        //    if (string.IsNullOrEmpty(token))
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        var result = _cacheContext.Get<UserAuthSession>(token) != null;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private string GetToken()
        //{
        //    string token = _httpContextAccessor.HttpContext.Request.Query["Token"];
        //    if (!String.IsNullOrEmpty(token)) return token;

        //    token = _httpContextAccessor.HttpContext.Request.Headers["X-Token"];
        //    if (!String.IsNullOrEmpty(token)) return token;

        //    var cookie = _httpContextAccessor.HttpContext.Request.Cookies["Token"];
        //    return cookie ?? String.Empty;
        //}

        public SysUser GetByStr(string username, string pwd)
        {
            SysUser user = _context.SysUsers.Where(a => a.Account == username && a.Password == pwd).Single();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
