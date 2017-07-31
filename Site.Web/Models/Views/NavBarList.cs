using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KenticoCloud.Delivery;

namespace Site.Web.Models.Views
{
    public class NavBarList
    {
        #region Constructors

        public NavBarList()
        {
        }

        #endregion



        #region Properties

        public List<ContentItem> ListItems { get; set; }
        public string Title { get; set; }

        #endregion
    }
}