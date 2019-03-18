using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Auth
{
    public class BaseController : Controller
    {
        public const string Token = "Token";

        protected IUserService _authUtil;

        public BaseController(IUserService authUtil)
        {
            _authUtil = authUtil;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var token = "";

            //Token by QueryString
            var request = filterContext.HttpContext.Request;
            if (request.Cookies[Token] != null)  //从Cookie读取Token
            {
                token = request.Cookies[Token];
            }

            if (string.IsNullOrEmpty(token))
            {
                //直接登录
                filterContext.Result = LoginResult("");
                return;
            }
            //验证
            if (_authUtil.CheckLogin(token, request.Path) == false)
            {
                //会话丢失，跳转到登录页面
                filterContext.Result = LoginResult("");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        public virtual ActionResult LoginResult(string username)
        {
            return new RedirectResult("/Login/Index");
        }
    }
}
