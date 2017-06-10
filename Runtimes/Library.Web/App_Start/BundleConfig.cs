using System.Web.Optimization;

namespace Library.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery")
            //   .Include("~/plugins/jQuery/jQuery-{version}.min.js"));

            bundles.UseCdn = true;


            #region [ Script Bundles ]


            // register jquery bundle from local file
            bundles.Add(new ScriptBundle("~/bundles/js/jquery")
                .Include("~/plugins/jQuery/jQuery-2.1.4.min.js"));

            // register datatable scripts from cdn
            string uikitjs = "https://cdn.datatables.net/1.10.15/js/dataTables.uikit.min.js";
            string datatablesjs = "https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js";

            bundles.Add(new ScriptBundle("~/bundles/js/uikit", uikitjs));
            bundles.Add(new ScriptBundle("~/bundles/js/datatablesjs", datatablesjs));

            // register local js files
            bundles.Add(new ScriptBundle("~/bundles/js/scripts")
                .Include(
                "~/bootstrap/js/bootstrap.min.js",
                "~/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/plugins/fastclick/fastclick.js",
                "~/dist/js/app.min.js",
                "~/dist/js/demo.js"));

            // register custom js files for database
            bundles.Add(new ScriptBundle("~/bundles/js/datatable")
                .Include(
                "~/Scripts/modifydatatable.js",
                "~/plugins/datatables/extentions/Responsive/js/dataTables.responsive.min.js"));



            #endregion

            #region [ Style Bundles ]

            // cdn for ionic and bootstrap
            string bootstrap = "https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css";
            string ionicCdn = "https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css";

            // cdns for uikit - datatable
            string uikit = "https://cdn.datatables.net/1.10.15/css/dataTables.uikit.min.css";
            string uikitmin = "//cdnjs.cloudflare.com/ajax/libs/uikit/2.24.3/css/uikit.min.css";

            // register bootstrap and ionic
            bundles.Add(new StyleBundle("~/bundles/css/bootstrap", bootstrap));
            bundles.Add(new StyleBundle("~/bundles/css/ionic", ionicCdn));

            // register uikit
            bundles.Add(new StyleBundle("~/bundles/css/uikit", uikit));
            bundles.Add(new StyleBundle("~/bundles/css/uikitmin", uikitmin));

            // register local css
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                    "~/bootstrap/css/bootstrap.min.css",
                    "~/dist/css/AdminLTE.min.css",
                    "~/dist/css/skins/_all-skins.min.css"));



            #endregion


            BundleTable.EnableOptimizations = true;
        }
    }
}