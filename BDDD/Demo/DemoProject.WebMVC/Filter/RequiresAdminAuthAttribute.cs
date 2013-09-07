using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoProject.WebMVC.Filter
{
    /// <summary>
    /// Admin登陆检查
    /// 并在验证失败时重定向到登录页
    /// </summary>
    public class RequiresAdminAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["LoginUser"] == null)
            {
                string redirectUrl = string.Format("?ReturnUrl={0}", filterContext.HttpContext.Request.Url.AbsolutePath);
                string loginUrl = "~/Admin/Login" + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}