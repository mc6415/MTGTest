using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;

namespace Site.Common.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns a Comma Delimited String Collection based on any Generic List.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="wrapInSingleQuotes"></param>
        /// <returns></returns>
        public static CommaDelimitedStringCollection ToCommaDelimitedStringCollection<T>(this List<T> list, bool wrapInSingleQuotes = false)
        {
            CommaDelimitedStringCollection commaList = new CommaDelimitedStringCollection();

            if (list.Count > 0)
            {
                foreach (object item in list)
                    commaList.Add(wrapInSingleQuotes ? $"'{item}'" : item.ToString());
            }

            return commaList;
        }

        /// <summary>
        /// Returns a random item from list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomItem<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default(T);

            if (list.Count == 1)
                return list[0];

            Random rnd = new Random(DateTime.Now.Millisecond);

            return list[(rnd.Next(0, list.Count))];
        }

        /// <summary>
        /// Randomise all items in a list collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="max"></param>
        public static void Shuffle<T>(this IList<T> list, int max = 0)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            int n = list.Count;

            if (list.Count >= max)
                n = max;

            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}