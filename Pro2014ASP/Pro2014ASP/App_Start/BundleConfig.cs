using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pro2014ASP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/css.css"
                //"~/Content/site.css"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Content/bootstrap.js",
                "~/Scripts/jquery-1.9.0.js"
            ));

            
        }
    }
}