using KenticoCloud.Delivery;
using Site.Common.Site;

namespace Site.Web.ContentLinkUrlResolver
{
    public class CustomContentLinkUrlResolver : IContentLinkUrlResolver
    {
        public string ResolveLinkUrl(ContentLink link)
        {
            switch (link.ContentTypeCodename)
            {
                case SiteConstants.KenticoCloud.ContentType.IndividualPage :
                    return $"/individualpage/{link.UrlSlug}";
                case SiteConstants.KenticoCloud.ContentType.Home :
                    return "/";
                default:
                    return "/Errors/NotFound";
            }
        }

        public string ResolveBrokenLinkUrl()
        {
            return "/Errors/NotFound";
        }
    }
}