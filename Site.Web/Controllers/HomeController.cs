using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KenticoCloud.Delivery;
using Site.Common.Site;
using Site.Web.Models.ContentTypes;
using Site.Web.Models.Views;

namespace Site.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        [Route]
        public async Task<ActionResult> Index()
        {
            //DeliveryItemResponse<Home> response = await Client.GetItemAsync<Home>(SiteConstants.KenticoCloud.ContentType.Home);

            //ViewBag.Title = response.Item.Title;
            //ViewBag.Description = response.Item.Summary;

            //HomeViewModel viewModel = new HomeViewModel
            //{
            //    Title = response.Item.Title,
            //    Summary = response.Item.Summary
            //};

            return View();
        }
    }
}