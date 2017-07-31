namespace Site.Common.Site
{
    public class SiteConstants
    {
        #region Classes

        /// <summary>
        /// Cache Keys.
        /// </summary>
        public static class CacheKey
        {
            #region Classes

            public static class Facebook
            {
                #region Fields

                public const string UserFriends = "UserFriends";

                #endregion
            }

            #endregion
        }

        /// <summary>
        /// Kentico Cloud.
        /// </summary>
        public static class KenticoCloud
        {
            #region Classes

            public static class ContentType
            {
                #region Fields

                public const string Category = "category";
                public const string FeaturedDeck = "featured_deck";
                public const string Home = "home";
                public const string IndividualPage = "project";

                #endregion
            }

            #endregion
        }

        #endregion
    }
}