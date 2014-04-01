using Planket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planket.Pages.AnnonsPages
{
    public partial class AnnonsDetails : System.Web.UI.Page
    {
        //Fält
        private Service _service;

        // Ett Service-objekt skapas först då det behövs för första gången
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        //Hämtar en annons med hjälp av routedata, matchande datakeyname på controlen
        public Annons AnnonsFormViewDitails_GetItem([RouteData] int id)
        {
            try
            {
                //Nytt service obj
                Service service = new Service();            
                var annons = service.GetAnnonsByID(id);

                //Hämtar katergorityperna från cachningen
                var ListkatTypesCach = Service.GetKategoriTypes();
                //Hämtar namnet på kategoritypen med hjälp av id
                foreach (var item in ListkatTypesCach)
                {
                    if (item.KategoriID == annons.KategoriID)
                    {
                        // get the value of the item in your loop
                        var NameOfKatType = item.Kategorityp;
                        annons.KategoriNamn = NameOfKatType;
                    }
                }

                //Hämtar lantyperna från cachningen
                var ListLanTypesCach = Service.GetLanTypes();
                //Hämtar namnet på kategoritypen med hjälp av id
                foreach (var item in ListLanTypesCach)
                {
                    if (item.LanID == annons.LanID)
                    {
                        // get the value of the item in your loop
                        var NameOfLanType = item.Lantyp;
                        annons.LanNamn = NameOfLanType;
                    }
                }
                return annons;
            }
            catch (Exception) //Fångar upp om någor gick fel
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då annonsen skulle hämtas.");
                return null;
            }
        }

        //Tar bort en annons med hjälp av id som "fångas" av "e.CommandArgument"
        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            //ModelState.IsValid = när man jobbar med data annotation(bindning)
            if (ModelState.IsValid)
            {
                try
                {
                    //Får ut id
                    var id = int.Parse(e.CommandArgument.ToString());

                    Service.DeleteAnnons(id);
                    //Skickar meddelande om att annonsen sparades
                    Page.SetTempData("SuccessMessage", "Annonsen är raderad.");
                    //Skickas till annonsen som har lagts in med hjälp av id
                    Response.RedirectToRoute("AnnonsList", null);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då annonsen skulle tas bort.");
                }
            }
        }    
    }
}