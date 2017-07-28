using System;
using System.Web;

namespace Site.Common.Web
{
    public class CookieProvider
    {
        private readonly string _name;

        public CookieProvider(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Gets cookie contents
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[_name];

            if (cookie != null && cookie.Value != null)
                return cookie.Value;
            else
                return string.Empty;
        }

        /// <summary>
        /// Create a cookie and assign a value.
        /// </summary>
        /// <param name="expiry">In hours.</param>
        /// <param name="value"></param>
        public void Set(int expiry, string value)
        {
            HttpCookie cookie = new HttpCookie(_name)
            {
                Value = value, 
                Expires = DateTime.Now.AddHours(expiry)
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        
        /// <summary>
        /// Deletes cookie.
        /// </summary>
        public void Remove()
        {
            HttpContext.Current.Request.Cookies.Remove(_name);
        }
    }
}
