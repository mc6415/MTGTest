using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KenticoCloud.Delivery;
using Site.Common.Site;

namespace Site.Web.Models.ContentTypes
{
    public class CustomTypeProvider : ICodeFirstTypeProvider
    {
        public Type GetType(string contentType)
        {
            switch (contentType)
            {
                case SiteConstants.KenticoCloud.ContentType.Home:
                    return typeof(Home);
                default:
                    return null;
            }
        }
    }
}