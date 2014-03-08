using System.Web;
using System.Web.Optimization;

namespace ModestoPower.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/mp").Include(
                      "~/Scripts/jquery.easing-1.3.pack.js",
                      "~/Scripts/jquery.sticky.js",
                      "~/Scripts/jquery.inview.js",
                      "~/Scripts/jquery.flexslider-min.js",
                      "~/Scripts/jquery.carouFredSel-6.2.1-packed.js",
                      "~/Scripts/parallax.js",
                      "~/Scripts/isotope.js",
                      "~/Scripts/nlform.js",
                      "~/Scripts/tweetable.jquery.min.js",
                      "~/Scripts/jflickrfeed.min.js",
                      "~/Scripts/odometer.min.js",
                      "~/Scripts/jquery.waitforimages.js",
                      "~/Scripts/jquery.knob.js",
                      "~/Scripts/mediaelement-and-player.min.js",
                      "~/Scripts/jquery.prettyPhoto.js",
                      "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jasny-bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/flexslider.css",
                      "~/Content/animate.css",
                      "~/Content/nlform.css",
                      "~/Content/jquery.vegas.css",
                      "~/Content/navigation.css",
                      "~/Content/odometer-theme-default.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/prettyPhoto.css",
                      "~/Content/main.css",
                      "~/Content/skins/color4.css"));
        }
    }
}
