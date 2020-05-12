using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SporApp.App_Start
{
    public class AuthActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext == null || filterContext.HttpContext.User == null || string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Login"
                }));
            }
        }
    }



    public class AdminAuthActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext == null || filterContext.HttpContext.User == null || string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Login"
                }));
            }
            else
            {
               bool isAdmin = Convert.ToBoolean(filterContext.HttpContext.User.Identity.Name.Split(',')[1]);
                if (!isAdmin)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Users",
                        action = "NotAuth"
                    }));
                }
            }
        }
    }
}