﻿using System.Web;
using System.Web.Optimization;

namespace ECommerce
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
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            // bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //     "~/node_modules/jquery/dist/jquery.js"));
            //
            // bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //     "~/node_modules/jquery-validation/dist/jquery.validate.js"));
            //
            // // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            // bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //     "~/node_modules/modernizr/bin/modernizr"));
            //
            // bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //     "~/node_modules/boostrap/dist/js/bootstrap.js"));
            //
            // bundles.Add(new StyleBundle("~/Content/css").Include(
            //     "~/node_modules/bootstrap/dist/css/bootstrap.css",
            //     "~/Content/site.css"));
        }
    }
}