using System.Web.Optimization;

namespace GridComponent
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles/vendors").Include(
                "~/Assets/Styles/Vendors/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/styles/custom").Include(
                "~/Assets/Styles/Custom/Site.css"));

            bundles.Add(new ScriptBundle("~/scripts/angular").Include(
                "~/Assets/Scripts/Vendors/angular.min.js",
                "~/Assets/Scripts/Custom/application.js",
                "~/Assets/Scripts/Custom/constants.js",
                "~/Assets/Scripts/Custom/directives.js"));

            bundles.Add(new ScriptBundle("~/scripts/Home/Index").Include(
                "~/Assets/Scripts/Custom/Home/Index/controllers.js"));
        }
    }
}