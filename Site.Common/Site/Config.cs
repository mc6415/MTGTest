using System.Configuration;
using Site.Common.Extensions;

namespace Site.Common.Site
{
    public class Config
    {
        public static class KenticoCloud
        {
            public static string ProjectId => ConfigurationManager.AppSettings["KenticoCloud.ProjectID"];
        }

        public static class Codenames
        {
            public static string Home => ConfigurationManager.AppSettings["Codename.Home"];
        }
    }
}