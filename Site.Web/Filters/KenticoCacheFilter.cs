using System.Web;
using System.Web.Mvc;

namespace Site.Web.Filters
{
    public class KenticoCacheFilter : OutputCacheAttribute
    {
        public KenticoCacheFilter()
        {
            Duration = HttpContext.Current.IsDebuggingEnabled ? 0 : 60;
        }
    }
}