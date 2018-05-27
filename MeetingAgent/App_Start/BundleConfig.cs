using System.Web;
using System.Web.Optimization;

namespace MeetingAgent
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { 

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.parallax.js",
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/smoothscroll.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/custom.js",
                    "~/Scripts/kendo/2016.2.607/kendo.all.min.js",
                    "~/Scripts/kendo/2016.2.607/kendo.aspnetmvc.min.js",
                    "~/Scripts/kendo/2016.2.607/messages/kendo.messages.alb-ALB.min.js",
                    "~/Scripts/kendo/2016.2.607/cultures/kendo.culture.en-GB.min.js",
                     "~/Scripts/kendoDefaultCulture.js"


            ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/owl.theme.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/style.css"
            ));


            bundles.Add(new StyleBundle("~/Content/kendo/2016.2.607/styles").Include(
                      "~/Content/kendo/2016.2.607/kendo.common.min.css",
                      "~/Content/kendo/2016.2.607/kendo.mobile.all.min.css",
                      "~/Content/kendo/2016.2.607/kendo.dataviz.min.css",
                      "~/Content/kendo/2016.2.607/kendo.bootstrap.min.css",
                      "~/Content/kendo/2016.2.607/kendo.dataviz.bootstrap.min.css"
            ));

        }
    }
}