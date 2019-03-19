using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PMS.Controllers
{
    /// <summary>
    /// 授权控制器基类
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
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
    }
}