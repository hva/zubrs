using System.Web.Optimization;
using NSass;

namespace Zubrs.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new SassBundle("~/bundles/css").Include(
                "~/sass/normalize.scss",
                "~/sass/site.scss"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                "~/Scripts/foundation/foundation.js",
                "~/Scripts/foundation/foundation.orbit.js",
                "~/Scripts/foundation/foundation.topbar.js"
            ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
