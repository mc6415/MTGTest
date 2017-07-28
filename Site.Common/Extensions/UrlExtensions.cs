using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;

namespace Site.Common.Extensions
{
    public static class UrlExtensions
    {
        /// <summary>
        /// Get domain from current http context.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCurrentDomain(this HttpContext context)
        {
            if (context != null)
                return $"{context.Request.Url.Scheme}{Uri.SchemeDelimiter}{context.Request.Url.Host}{(!context.Request.Url.IsDefaultPort ? $":{context.Request.Url.Port}" : null)}";

            return string.Empty;
        }

        /// <summary>
        /// Accepts query string part of a URL to allow a single value to be returned based on parameter name.
        /// </summary>
        /// <param name="urlParameters"></param>
        /// <returns></returns>
        public static StringDictionary GetQuerystringParameter(this string urlParameters)
        {
            urlParameters = $"{urlParameters}&";

            StringDictionary parameterDictionary = new StringDictionary();

            Regex r = new Regex(@"(?<name>[^=&]+)=(?<value>[^&]+)&", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            IEnumerator enums = r.Matches(urlParameters).GetEnumerator();

            while (enums.MoveNext() && enums.Current != null)
                parameterDictionary.Add(((Match)enums.Current).Result("${name}"), ((Match)enums.Current).Result("${value}"));

            return parameterDictionary;
        }
    }
}