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

       

        #endregion
    }
}