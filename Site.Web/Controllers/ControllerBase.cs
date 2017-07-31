using HtmlAgilityPack;
using KenticoCloud.Delivery;
using Site.Common.Site;
using Site.Web.ContentLinkUrlResolver;
using Site.Web.Models.ContentTypes;
using Site.Web.Models.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Site.Web.Filters;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;
using TwitchLib.Models.API;

namespace Site.Web.Controllers
{
    public class ControllerBase : AsyncController
    {
        #region Fields

        public string MajorEventsXPath = "//div[@class='page']/div/table/tr/td[2]/table[1]/tr/td[1]/a";
        protected readonly DeliveryClient Client = new DeliveryClient(Config.KenticoCloud.ProjectId);

        #endregion

        #region Constructors

        public ControllerBase()
        {
            Client.CodeFirstModelProvider.TypeProvider = new CustomTypeProvider();
            Client.ContentLinkUrlResolver = new CustomContentLinkUrlResolver();
        }

        #endregion



        #region Methods

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

        [KenticoCacheFilter]
        public async Task<NavBarList> GetNavbarCategories()
        {
            DeliveryItemListingResponse response = await Client.GetItemsAsync(
                new EqualsFilter("system.type", SiteConstants.KenticoCloud.ContentType.Category),
                new AnyFilter("elements.in_navbar", "yes")
            );

            NavBarList listItems = new NavBarList()
            {
                Title = "Categories",
                ListItems = response.Items.ToList()
            };

            return listItems;
        }

        public async Task<bool> GetTwitchStatus()
        {
            TwitchAPI.Settings.ClientId = Config.Twitch.ClientId;

            bool isStreaming = await TwitchAPI.Streams.v5.BroadcasterOnlineAsync(Config.Twitch.UserId);

            return isStreaming;
        }

        protected override async void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //ViewBag.StandardEvents = GetEvents("http://mtgtop8.com/format?f=ST", "Standard Events");
            //ViewBag.ModernEvents = GetEvents("http://mtgtop8.com/format?f=MO", "Modern Events");
            ViewBag.IsStreaming = await GetTwitchStatus();
            ViewBag.NavbarCategories = await GetNavbarCategories();

            base.OnActionExecuting(filterContext);
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

        #endregion
    }
}