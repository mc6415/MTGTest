using KenticoCloud.Delivery;

namespace Site.Web.Models.ContentTypes
{
    public class Home
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}