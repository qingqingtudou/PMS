using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Infrastructure.Cache;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;

namespace PMS.Controllers
{
    /// <summary>
    /// 授权控制器基类
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController(ICacheContext cacheContext, IUserService userService)
        {
            _cacheContext = cacheContext;
            _userService = userService;
        }

        public ICacheContext _cacheContext;
        public IUserService _userService;

        /// <summary>
        /// 当前登录用户的用户名
        /// </summary>
        public string Account
        {
            get
            {
                //获取用户信息
                var claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
                var claimsPrincipal = claimIdentity.Claims as List<Claim>;
                return claimsPrincipal[3].Value;
            }
        }

        /// <summary>
        /// 当前用户Id
        /// </summary>
        public int UserId
        {
            get
            {
                var claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
                var claimsPrincipal = claimIdentity.Claims as List<Claim>;
                return Convert.ToInt32(claimsPrincipal[1].Value);
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public SysUser CurrentUser
        {
            get
            {
                var curentUser = _cacheContext.Get<SysUser>(Account);
                if (curentUser == null)
                {
                    var user = _userService.GetSysUserById(UserId);
                    _cacheContext.Set(Account, user, DateTime.Now.AddDays(1));
                }
                curentUser = _cacheContext.Get<SysUser>(Account);
                return curentUser;
            }
        }
    }
}