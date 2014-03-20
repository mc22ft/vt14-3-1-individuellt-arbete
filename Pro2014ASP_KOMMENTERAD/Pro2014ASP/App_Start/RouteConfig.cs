using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Pro2014ASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
                //Länkar "vidare" och sätter url namnet. Med en egenskap 
            routes.MapPageRoute("Listing", "Annonser", "~/Pages/AddPages/Listing.aspx");
            routes.MapPageRoute("AddCreate", "Annonser/nyAnnons", "~/Pages/AddPages/CreateAdd.aspx");            
            routes.MapPageRoute("AddDetails", "Annonser/{id}", "~/Pages/AddPages/DetailsAdd.aspx");
            routes.MapPageRoute("AddEdit", "Annonser/{id}/redigera", "~/Pages/AddPages/AddEdit.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/AddPages/Listing.aspx");
        }
    }
}