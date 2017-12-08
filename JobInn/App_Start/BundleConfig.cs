using System.Web;
using System.Web.Optimization;

namespace JobInn
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //userpage layout------------------------------------------

            bundles.Add(new StyleBundle("~/Content/css1").Include(
                "~/Content/css/custom.css",
                "~/Content/css/color.css",
                "~/Content/css/responsive.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/jquery.mCustomScrollbar.css",
                "~/Content/css/bootstrap.css"
           ));

            bundles.Add(new ScriptBundle("~/Content/bootstrap").Include(
                     "~/Content/js/bootstrap.min.js"
                ));


            bundles.Add(new ScriptBundle("~/Content/jquery").Include(
                      "~/Content/js/custom.js",
                "~/Content/js/jquery.mCustomScrollbar.concat.min.js",
                "~/Content/js/jquery.kenburnsy.js",
                 "~/Content/js/jquery.velocity.min.js",
                "~/Content/js/owl.carousel.min.js",
                "~/Content/js/jquery-1.11.3.min.js"
                ));

        }
    }
}
