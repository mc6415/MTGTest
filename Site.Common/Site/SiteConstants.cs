namespace Site.Common.Site
{
    public class SiteConstants
    {
        /// <summary>
        /// Cache Keys.
        /// </summary>
        public static class CacheKey
        {
            public static class Facebook
            {
                public const string UserFriends = "UserFriends";
            }
        }

        /// <summary>
        /// Kentico Cloud.
        /// </summary>
        public static class KenticoCloud
        {
            public static class ContentType
            {
                public const string Home = "home";
                public const string IndividualPage = "project";
                public const string FeaturedDeck = "featured_deck";
            }
        }
    }
}