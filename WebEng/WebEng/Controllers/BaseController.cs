using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebEng.Common;

namespace WebEng.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (TaiKhoanLogin)Session[CommonConstants.USER_SESSION];
            
            if (session == null )
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Area = "", controller = "Login", action = "Index"}));
                string re = filterContext.Result.ToString();
            }
           

            base.OnActionExecuted(filterContext);
        }
    }
}