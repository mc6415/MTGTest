using Site.Web.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Site.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        #region Methods

        [Route]
        [KenticoCacheFilter]
        public async Task<ActionResult> Index()
        {
            //DeliveryItemResponse<Home> response = await Client.GetItemAsync<Home>(SiteConstants.KenticoCloud.ContentType.Home);
            await GetFeaturedDecks();
            await GetTwitchStatus();
            return View();
        }

        #endregion
    }
}