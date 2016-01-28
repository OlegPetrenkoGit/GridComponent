using System.Web.Optimization;

namespace GridComponent
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"
              ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/Vendors/jquery-1.10.2.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Vendors/angular.min.js",
                "~/Scripts/application.js",
                "~/Scripts/directives.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Index").Include(
               "~/Scripts/Home/Index/controllers.js"
               ));
        }
    }
}