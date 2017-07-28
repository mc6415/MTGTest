using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KenticoCloud.Delivery;

namespace Site.Web.Models.ContentTypes
{
    public class IndividualPage
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}