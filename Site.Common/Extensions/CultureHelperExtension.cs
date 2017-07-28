using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Site.Common.Extensions
{
    public static class CultureHelperExtension
    {
        /// <summary>
        /// Returns a country name.
        /// </summary>
        /// <param name="countryTwoLettersCode"></param>
        /// <returns></returns>
        public static string GetCountryFromCode(string countryTwoLettersCode)
        {
            IEnumerable<RegionInfo> regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));

            RegionInfo region = regions.FirstOrDefault(r => r.TwoLetterISORegionName.Contains(countryTwoLettersCode.ToUpper()));

            return region?.DisplayName;
        }
    }
}
