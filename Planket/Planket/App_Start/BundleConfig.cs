using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Planket
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Inlänkade css, min egen css och boostrap
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/Style.css"
            ));

            //Inlänkade javascript
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Content/bootstrap.js",
                "~/Scripts/jquery-1.9.0.js"
            ));


        }
    }
}