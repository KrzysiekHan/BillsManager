using System.Web;
using System.Web.Optimization;

namespace MvcUI
{
    public class BundleConfig
    {
        // Aby uzyskać więcej informacji o grupowaniu, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/thirdParty").Include(
                      "~/lib/toastr.js/toastr.min.js",
                      "~/lib/Chart.js/Chart.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/lib/toastr.js/toastr.css",
                      "~/lib/Chart.js/Chart.min.css",
                      "~/Content/site.css"));
        }
    }
}
