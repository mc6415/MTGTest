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
using Site.Web.Models.Views;

namespace Site.Web.Controllers
{
    public class ControllerBase : AsyncController
    {
        protected readonly DeliveryClient Client = new DeliveryClient(Config.KenticoCloud.ProjectId);

        public string MajorEventsXPath = "//div[@class='page']/div/table/tr/td[2]/table[1]/tr/td[1]/a";

        public ControllerBase()
        {
            Client.CodeFirstModelProvider.TypeProvider = new CustomTypeProvider();
            Client.ContentLinkUrlResolver = new CustomContentLinkUrlResolver();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.StandardEvents = GetEvents("http://mtgtop8.com/format?f=ST", "Standard Events");
            ViewBag.ModernEvents = GetEvents("http://mtgtop8.com/format?f=MO", "Modern Events");

            base.OnActionExecuting(filterContext);
        }

        public EventList GetEvents(string url, string title)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            EventList eventList = new EventList();
            eventList.Title = title;
            eventList.Events = new List<string>();

            var events = doc.DocumentNode.SelectNodes(MajorEventsXPath).ToList();

            foreach (var ev in events)
            {
                eventList.Events.Add(ev.OuterHtml);
            }

            return eventList;
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