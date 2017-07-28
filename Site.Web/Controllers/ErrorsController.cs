using System;
using System.Web.Mvc;

namespace Site.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;

            return View();
        }
        
        public ActionResult Exception()
        {
            Exception ex = (Exception)this.Session["Exception"];

            if (!(ex is null))
                return View(ex);
            else
                return View(new Exception());
        }

    }
}