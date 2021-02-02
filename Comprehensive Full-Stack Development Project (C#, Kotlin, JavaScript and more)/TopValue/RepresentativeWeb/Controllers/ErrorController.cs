using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIgSystemSolutions_Web.Controllers
{
    public class ErrorController : Controller
    {
        [ActionName("404")]
        public ActionResult BadRequest()
        {
            return View();
        }

        [ActionName("500")]
        public ActionResult InternalServerError()
        {
            return View();
        }
    }
}