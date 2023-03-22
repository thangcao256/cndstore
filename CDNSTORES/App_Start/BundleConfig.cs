using System.Web;
using System.Web.Optimization;

namespace CDNSTORES
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
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/shop_detail").Include(

                    "~/Scripts/js/imagezoom.js",
                    "~/Scripts/js/jquery.flexslider.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/script_movie").Include(

                    "~/Scripts/js/bootstrap.js",
                    "~/Scripts/js/jquery-2.1.4.min.js",
                    "~/Scripts/js/jquery.magnific-popup.js",
                    "~/Scripts/js/minicart.js",
                    "~/Scripts/js/jquery-ui.js",
                    "~/Scripts/js/jquery.flexisel.js",
                    "~/Scripts/js/SmoothScroll.min.js",
                    "~/Scripts/js/move-top.js",
                    "~/Scripts/js/easing.js"


                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //bundles.Add(new StyleBundle("~/Content/shop_css").Include(
            //            "~/Content/bootstrap.css",
            //          "~/Content/site.css",
            //            "~/Content/css/bootstrap.css",
            //          //"~/Content/css/style.css",
            //          "~/Content/css/font-awesome.css",
            //          "~/Content/css/popuo-box.css",
            //          "~/Content/css/jquery-ui1.css",
            //          "~/Content/css/flexslider.css"
            //          ));

        }
    }
}
