using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Site.Common.Web
{
    public class CacheEngine
    {
        private static readonly ObjectCache Cache = MemoryCache.Default;

        /// <summary>
        /// Retrieve cached item.
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)Cache[key];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Insert value into the cache using appropriate name/value pairs.
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="minutes">Number of minutes for object to stay in cache</param>
        public static void Add<T>(T objectToCache, string key, int minutes) where T : class
        {
            Cache.Add(key, objectToCache, DateTime.Now.AddMinutes(minutes));
        }

        /// <summary>
        /// Insert value into the cache using appropriate name/value pairs.
        /// </summary>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="minutes">Number of minutes for object to stay in cache</param>
        public static void Add(object objectToCache, string key, int minutes)
        {
            Cache.Add(key, objectToCache, DateTime.Now.AddMinutes(minutes));
        }

        /// <summary>
        /// Remove item from cache.
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Check for item in cache.
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return Cache.Get(key) != null;
        }

        /// <summary>
        /// Gets all cached items as a list by their key.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAll()
        {
            return Cache.Select(keyValuePair => keyValuePair.Key).ToList();
        }

        /// <summary>
        /// Caches static resources, such as CSS and JavaScript.
        /// </summary>
        /// <param name="rootRelativePath"></param>
        /// <returns></returns>
        public static string StaticFileCacheBuster(string rootRelativePath)
        {
            if (!HttpContext.Current.IsDebuggingEnabled)
            {
                if (HttpRuntime.Cache[rootRelativePath] == null)
                {
                    string fileAbsolutePath = HostingEnvironment.MapPath($"~{rootRelativePath}");

                    DateTime date = File.GetLastWriteTime(fileAbsolutePath);
                    int index = rootRelativePath.LastIndexOf('/');

                    string result = rootRelativePath.Insert(index, $"/v{date.Ticks}");
                    HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(fileAbsolutePath));
                }

                return HttpRuntime.Cache[rootRelativePath].ToString();
            }
            else
            {
                return rootRelativePath;
            }
        }
    }
}
