using System;
using KenticoCloud.Delivery;

namespace Site.Web.Models.ContentTypes
{
    public class CustomTypeProvider : ICodeFirstTypeProvider
    {
        public Type GetType(string contentType)
        {
            return null;
        }
    }
}