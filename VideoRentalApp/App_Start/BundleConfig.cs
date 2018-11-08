using System.Web;
using System.Web.Optimization;

namespace VideoRentalApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.js",
                "~/Scripts/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-lumen-v4.css",
                "~/Content/DataTables/css/dataTables.bootstrap4.css",
                "~/Content/typeaheadB4.css",
                "~/Content/Site.css"));
        }
    }
}