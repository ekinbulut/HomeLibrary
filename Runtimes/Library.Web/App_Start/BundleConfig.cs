using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/plugins/jQuery/jQuery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include(new string[]
                {

                    "~/bootstrap/js/bootstrap.min.js",
                    "~/plugins/datatables/jquery.dataTables.min.js",
                    "~/plugins/datatables/dataTables.bootstrap.min.js",
                    "~/plugins/slimScroll/jquery.slimscroll.min.js",
                    "~/plugins/fastclick/fastclick.js",
                    "~/dist/js/app.min.js",
                    "~/dist/js/demo.js"

                }));

            bundles.Add(new ScriptBundle("~/bundles/datatable")
                .Include(new string[]
                {
                    "~/Scripts/modifydatatable.js",
                    "~/plugins/datatables/extentions/Responsive/js/dataTables.responsive.min.js"


                }));

            string bootstrap = "https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css";
            string ionicCdn = "https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css";

            bundles.Add(new StyleBundle("~/bundles/bootstrap", bootstrap));
            bundles.Add(new StyleBundle("~/bundles/ionic", ionicCdn));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/bootstrap/css/bootstrap.min.css",
                "~/plugins/datatables/dataTables.bootstrap.css",
                "~/dist/css/AdminLTE.min.css",
                "~/dist/css/skins/_all-skins.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}