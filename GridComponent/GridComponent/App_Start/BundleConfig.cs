using System.Web.Optimization;

namespace GridComponent
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Libraries/angular.min.js",
                "~/Scripts/application.js"));

            bundles.Add(new ScriptBundle("~/bundles/Index").Include(
               "~/Scripts/Home/Index/controllers.js"));
        }
    }
}