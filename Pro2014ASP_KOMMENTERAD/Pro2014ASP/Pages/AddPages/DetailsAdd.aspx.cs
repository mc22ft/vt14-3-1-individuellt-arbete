using Pro2014ASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro2014ASP
{
    public partial class DetailsAdd : System.Web.UI.Page
    {
        //Fält
        private Service _service;

        // Ett Service-objekt skapas först då det behövs för första gången
        private Service Service
        {          
            get { return _service ?? (_service = new Service()); }
        }

        //Visar meddelande i ValidationSummary om ModelState får felmeddelande (längre ner)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Success2"] as bool? == true)
            {                
                Session.Remove("Success2");
            }
        }
                
        //Hämtar en annons med hjälp av routedata, matchande datakeyname på controlen
        public Pro2014ASP.Model.Add FormViewDitailsAdd_GetItem([RouteData] int id) //[RouteData] 
        {
            try
            {
                Service service = new Service();
                return service.GetAdd(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då annonsen skulle hämtas.");
                return null;
            }     
        }

        //Tar bort en annons med hjälp av id som "fångas" av "e.CommandArgument"
        protected void DeleteLinkButton_Command1(object sender, CommandEventArgs e)
        {
            //ModelState.IsValid = när man jobbar med data annotation(bindning)
            if (ModelState.IsValid) 
            {
                try
                {
                    //Får ut id
                    var id = int.Parse(e.CommandArgument.ToString());

                    Service.DeleteAdd(id);
                    //Meddelande om delete av annons lyckades
                    Session["Success2"] = true;
                    Response.RedirectToRoute("Listing", null);
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