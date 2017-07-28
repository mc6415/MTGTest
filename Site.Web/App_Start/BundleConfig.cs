using System.Web.Optimization;

namespace Site.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"
            ));

            bundles.Add(new StyleBundle("~/Style/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-flat.css"
            ));

            bundles.Add(new StyleBundle("~/Style/site").Include(
                "~/Content/site.css"
            ));
        }
    }
}