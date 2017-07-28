using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KenticoCloud.Delivery;
using Site.Common.Site;
using Site.Web.ContentLinkUrlResolver;
using Site.Web.Models.ContentTypes;
using HtmlAgilityPack;

namespace Site.Web.Controllers
{
    public class ControllerBase : AsyncController
    {
        protected readonly DeliveryClient Client = new DeliveryClient(Config.KenticoCloud.ProjectId);

        public string MajorEventsXPath = "//div[@class='page']/div/table/tr/td[2]/table[1]/tr/td[1]";

        public ControllerBase()
        {
            Client.CodeFirstModelProvider.TypeProvider = new CustomTypeProvider();
            Client.ContentLinkUrlResolver = new CustomContentLinkUrlResolver();
        }

        public void GetStandardEvents()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://mtgtop8.com/format?f=ST");

            List<string> eventNames = new List<string>();

            var events = doc.DocumentNode.SelectNodes(MajorEventsXPath).ToList();

            foreach (var ev in events)
            {
                eventNames.Add(ev.InnerText);
            }
        }

        public void GetModernEvents()
        {
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //if (HttpContext.IsDebuggingEnabled)
            //{
            //    filterContext.ExceptionHandled = true;
            //    this.Session["Exception"] = filterContext.Exception;
            //    filterContext.Result = RedirectToAction("Exception", "Errors");
            //}
            //else
            base.OnException(filterContext);
        }
    }
}