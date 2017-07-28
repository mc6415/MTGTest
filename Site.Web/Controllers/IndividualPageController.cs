using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KenticoCloud.Delivery;
using Site.Common.Site;
using Site.Web.Models.ContentTypes;

namespace Site.Web.Controllers
{
    [RoutePrefix("pages")]
    public class IndividualPageController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [Route("{urlSlug}")]
        public async Task<ActionResult> Detail(string urlSlug)
        {
            IndividualPage item = (await Client.GetItemsAsync<IndividualPage>(new EqualsFilter("elements.page_url", urlSlug), new InFilter("system.type", SiteConstants.KenticoCloud.ContentType.IndividualPage))).Items.FirstOrDefault();

            if (item == null)
                throw new HttpException(404, "Not found");
            else
                return View(item);
        }
    }
}