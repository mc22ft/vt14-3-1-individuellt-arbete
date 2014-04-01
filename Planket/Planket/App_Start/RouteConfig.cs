using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Planket.App_Start
{
    //Länkar
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Annonser
            routes.MapPageRoute("AnnonsList", "Annonser", "~/Pages/AnnonsPages/AnnonsList.aspx");
            routes.MapPageRoute("AnnonsCreate", "Annonser/nyAnnons", "~/Pages/AnnonsPages/AnnonsCreate.aspx");
            routes.MapPageRoute("AnnonsDetails", "Annons/{id}", "~/Pages/AnnonsPages/AnnonsDetails.aspx");
            routes.MapPageRoute("AnnonsEdit", "Annonser/{id}/redigera", "~/Pages/AnnonsPages/AnnonsEdit.aspx");
            //Kategorier
            routes.MapPageRoute("KategoriPage", "Kategori/redigeraKategori", "~/Pages/KategoriPages/KategoriPage.aspx");           
            //Deafult
            routes.MapPageRoute("Default", "", "~/Pages/AnnonsPages/AnnonsList.aspx");
        }
    }
}