using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Planket
{
    public static class PageExtensions
    {
        //Hämtar temporär data
        public static object GetTempData(this Page page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);
            return value;
        }

        public static object PeekTempData(this Page page, string key)
        {
            return page.Session[key];
        }

        //Sätter temporär data
        public static void SetTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}