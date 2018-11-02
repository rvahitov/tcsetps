using System.Web.Optimization;

namespace Correct.Storage.Portal
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/vendor/knockout").Include("~/node_modules/knockout/build/output/knockout-latest.js"));
            bundles.Add(new ScriptBundle("~/scripts/vendor/jquery").Include("~/node_modules/jquery/dist/jquery.js"));
            bundles.Add(new ScriptBundle("~/scripts/vendor/popper.js").Include("~/node_modules/popper.js/dist/popper.js"));
            bundles.Add(new ScriptBundle("~/scripts/vendor/bootstrap").Include("~/node_modules/bootstrap/dist/js/bootstrap.js"));
            bundles.Add(new StyleBundle("~/styles/vendor/bootstrap").Include("~/node_modules/bootstrap/dist/css/bootstrap.css"));
        }
    }
}