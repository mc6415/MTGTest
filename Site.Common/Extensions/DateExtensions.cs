using System;

namespace Site.Common.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Converts standard date time to a timestamp.
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static long ToTimestampInSeconds(this DateTime currentDate)
        {
            DateTime timestampStart = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan elapsedTime = currentDate - timestampStart;

            return (long)elapsedTime.TotalSeconds;
        }
    }
}
