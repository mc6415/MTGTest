using System.Web;

namespace Site.Common.Web
{
    public class SessionProvider
    {
        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public static void Add(string key, object item)
        {
            HttpContext.Current.Session[key] = item;
        }

        /// <summary>
        /// Gets a session value based on the required type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key) where T : class
        {
            return HttpContext.Current.Session[key] as T;
        }

        /// <summary>
        /// Deletes a session/
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}
