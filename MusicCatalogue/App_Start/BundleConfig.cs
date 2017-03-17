using System.Web;
using System.Web.Optimization;

namespace MusicCatalogue
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
            "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            "~/Scripts/jquery.inputmask/inputmask.js",
            "~/Scripts/jquery.inputmask/jquery.inputmask.min.js",
            "~/Scripts/jquery.inputmask/inputmask.extensions.js",
            "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
            //and other extensions you want to include
            "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));


        bundles.Add(new ScriptBundle("~/bundles/jupload").Include(

"~/Scripts/jquery.ui.widget.js",
"~/Scripts/jQuery.FileUpload/jquery.iframe-transport.js",
"~/Scripts/jQuery.FileUpload/jquery.fileupload.js"






          ));


        


        }


}
}
