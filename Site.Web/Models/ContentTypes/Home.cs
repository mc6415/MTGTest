using System.Collections.Generic;
using KenticoCloud.Delivery;

namespace Site.Web.Models.ContentTypes
{
    public class Home
    {
        #region Properties

        public IEnumerable<Article> Articles { get; set; }
        public string Summary { get; set; }
        public ContentItemSystemAttributes System { get; set; }
        public string Title { get; set; }

        #endregion
    }
}