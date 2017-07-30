using System.Configuration;

namespace Site.Common.Site
{
    public class Config
    {
        #region Classes

        public static class Apis
        {
            #region Properties

            public static string MailChimpKey => ConfigurationManager.AppSettings["MailChimp.ApiKey"];
            public static string SendInBlueKey => ConfigurationManager.AppSettings["SendInBlue.ApiKey"];

            #endregion
        }

        public static class Codenames
        {
            #region Properties

            public static string Home => ConfigurationManager.AppSettings["Codename.Home"];

            #endregion
        }

        public static class KenticoCloud
        {
            #region Properties

            public static string ProjectId => ConfigurationManager.AppSettings["KenticoCloud.ProjectID"];

            #endregion
        }

        public static class Twitch
        {
            #region Properties

            public static string ClientId => ConfigurationManager.AppSettings["Twitch.ClientId"];
            public static string UserId => ConfigurationManager.AppSettings["Twitch.UserId"];

            #endregion
        }

        #endregion
    }
}