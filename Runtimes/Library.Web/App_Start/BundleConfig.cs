using Library.Web.Helpers;
using System.Web.Optimization;

namespace Library.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            AddSciptBundles(bundles);
            AddStyleBundles(bundles);

            BundleTable.EnableOptimizations = true;
        }

        private static void AddSciptBundles(BundleCollection bundles)
        {
                        // register jquery bundle from local file
            bundles.Add(new ScriptBundle(ScriptBundleParameters.JqueryBundles)
                .Include(ScriptBundleParameters.JqueryPlugins));

            // register local js files
            bundles.Add(new ScriptBundle(ScriptBundleParameters.JqueryBundleScripts)
                .Include(
                ScriptBundleParameters.BootStrapMinJs,
                ScriptBundleParameters.JquerySlimScroll,
                ScriptBundleParameters.FastClick,
                ScriptBundleParameters.AppMinJs,
                ScriptBundleParameters.Demo));

            // register datatable scripts from cdn
            string uikitjs = ScriptBundleParameters.UIKitJs;
            string datatablesjs = ScriptBundleParameters.DataTableJs;

            bundles.Add(new ScriptBundle(ScriptBundleParameters.UIKitJsBundle, uikitjs));
            bundles.Add(new ScriptBundle(ScriptBundleParameters.DataTableJsBundle, datatablesjs));



            // register custom js files for database
            bundles.Add(new ScriptBundle(ScriptBundleParameters.CustomDataTableJsBundle)
                .Include(
                ScriptBundleParameters.CustomDataTableScript,
                ScriptBundleParameters.CustomDataTablePlugin));

            // register morris
            string morris = ScriptBundleParameters.Morris;

            bundles.Add(new ScriptBundle(ScriptBundleParameters.MorrisCdnBundle,morris));
            bundles.Add(new ScriptBundle(ScriptBundleParameters.MorrisBundle)
                .Include(ScriptBundleParameters.MorrisScript));

        }

        private static void AddStyleBundles(BundleCollection bundles)
        {
            // register local css
            bundles.Add(new StyleBundle(StyleBundleParameters.Css)
                .Include(
                    StyleBundleParameters.BootStrapMinJs,
                    StyleBundleParameters.AdminLTE,
                    StyleBundleParameters.Skins));

            // register bootstrap and ionic
            string bootstrap = StyleBundleParameters.BootstrapCDN;
            string ionicCdn = StyleBundleParameters.IonicCDN;

            bundles.Add(new StyleBundle(StyleBundleParameters.BootstrapCss, bootstrap));
            bundles.Add(new StyleBundle(StyleBundleParameters.IonicCss, ionicCdn));

            // register uikit
            string uikit = StyleBundleParameters.UIKitCssCDN;
            string uikitmin = StyleBundleParameters.UIKitCssMinCDN;

            bundles.Add(new StyleBundle(StyleBundleParameters.UIKitCss, uikit));
            bundles.Add(new StyleBundle(StyleBundleParameters.UIKitCssMin, uikitmin));

            // register morris
            bundles.Add(new StyleBundle(StyleBundleParameters.MorrisCssBundle)
                .Include(StyleBundleParameters.MorrisCss));

        }
    }
}