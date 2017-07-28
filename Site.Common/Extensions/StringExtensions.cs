using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Site.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Check if the class name is equal to the value specified (case insensitive).
        /// </summary>
        /// <param name="className"></param>
        /// <param name="classNameToCompare"></param>
        /// <returns></returns>
        public static bool ClassNameEqualTo(this string className, string classNameToCompare)
        {
            return string.Equals(className, classNameToCompare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Remove any HTML tags from the string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string value)
        {
            return Regex.Replace(value, @"<[^>]*>", string.Empty).Replace("&nbsp;", string.Empty);
        }

        /// <summary>
        /// Remove empty paragraph tags from the string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveEmptyParagraphTags(this string value)
        {
            return Regex.Replace(value, @"<p>(\s|&nbsp;|</?\s?br\s?/?>)*</?p>", string.Empty);
        }

        /// <summary>
        /// Select the GUID via regex from the string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetGuid(this string value)
        {
            Match match = Regex.Match(value, "[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}", RegexOptions.IgnoreCase);

            if (match.Success)
                return match.Value;

            return string.Empty;
        }

        /// <summary>
        /// Format CMS rich text editor content.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatCmsContent(this string value)
        {
            // Replace tilde url paths with a standard url path.
            value = Regex.Replace(value, @"href=""~\/", "href=\"/");

            // Replace tilde src media library paths with a standard src path.
            value = Regex.Replace(value, @"src=""~\/(?:getmedia\/)", "src=\"/getmedia/");

            // Replace tilde src paths with a http/https src path.
            value = Regex.Replace(value, @"src=""~\/", "src=\"//");

            return value;
        }

        /// <summary>
        /// Truncate the string to the nearest word.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateAtWord(this string value, int length)
        {
            if (value == null || value.Length < length)
                return value;

            // Account for ellipsis character length if there are enough characters.
            length = length > 2 ? length - 3 : length;

            int nextSpace = value.LastIndexOf(" ", length, StringComparison.Ordinal);
            return $"{value.Substring(0, (nextSpace > 0) ? nextSpace : length).Trim()}...";
        }

        /// <summary>
        /// Truncate the string by the character count.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateAtLetter(this string value, int length)
        {
            if (value == null || value.Length <= length)
                return value;

            // Account for ellipsis character length if there are enough characters.
            length = length > 2 ? length - 3 : length;

            return $"{value.Substring(0, length).Trim()}...";
        }

        /// <summary>
        /// Convert a string into a URL slug.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSlug(this string value)
        {
            // Remove all accents.
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);

            // Replace spaces.
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            // Replace underscores with hyphens.
            value = Regex.Replace(value, @"_", "-", RegexOptions.Compiled);

            // Remove invalid chars.
            value = Regex.Replace(value, @"[^a-zA-Z0-9\s-_]", "", RegexOptions.Compiled);

            // Trim dashes from end.
            value = value.Trim('-', '_');

            // Replace double occurences of '-' or '_'.
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }

        /// <summary>
        /// Format string value into a time.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTime(this string value)
        {
            string[] timeSplitArr = value.Split(':');

            return $"{timeSplitArr[0]}:{timeSplitArr[1]}{timeSplitArr[2]}";
        }

        /// <summary>
        /// Select all alphanumeric characters from the string value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Clean(this string value)
        {
            return Regex.Replace(value, "[^A-Za-z0-9 ]", string.Empty);
        }

        /// <summary>
        /// Convert a string from a URL slug back into the original string.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string UnslugifyTagName(this string tag)
        {
            return tag.Replace("-", " ").Replace("-and-", "&");
        }

        /// <summary>
        /// Convert a string into URL slug.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string SlugifyTagName(this string tag)
        {
            return tag.Replace(" ", "-").Replace("&", "-and-");
        }

        /// <summary>
        /// Returns the Id in a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ExtractNumber(this string value)
        {
            return !string.IsNullOrEmpty(value) ? Regex.Replace(value, @"[^\d]", string.Empty) : value;
        }

        /// <summary>
        /// Checks if json syntax is valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsJson(this string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }

        /// <summary>
        /// Gets the ticket name and retrieves the band name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ExtractBandFromTicketName(this string value)
        {
            Match regMatch = Regex.Match(value, @"((Band) \w{0,1}){0,6}\b");

            if (regMatch.Success)
                return regMatch.Value;
            else
                return string.Empty;
        }

        /// <summary>
        /// Checks if a single string value is within two letters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startLetter"></param>
        /// <param name="endLetter"></param>
        /// <returns></returns>
        public static bool IsStringWithinRange(this char value, string startLetter, string endLetter)
        {
            return (string.CompareOrdinal(value.ToString(), startLetter) > 0 && string.CompareOrdinal(value.ToString(), endLetter) < 0);
        }
    }
}