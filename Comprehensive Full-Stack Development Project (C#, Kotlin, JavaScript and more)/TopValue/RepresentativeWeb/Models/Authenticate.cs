using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;

namespace BIgSystemSolutions_Web.Models
{
    public class AuthenticateAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["User"] as User;
            if (user == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectResult("/Dashboard/Login");
            }
        }
    }
}