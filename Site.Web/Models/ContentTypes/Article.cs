using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KenticoCloud.Delivery;

namespace Site.Web.Models.ContentTypes
{
    public class Article
    {
        #region Properties

        public IEnumerable<ContentItem> ArticleContent { get; set; }
        public IEnumerable<Asset> ArticleImage { get; set; }

        public string Author { get; set; }
        public string Blurb { get; set; }
        public IEnumerable<ContentItem> Categories { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }

        #endregion
    }
}