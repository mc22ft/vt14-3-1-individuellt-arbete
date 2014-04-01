using Planket.Model;
using Planket.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planket.Pages.AnnonsPages
{
    public partial class AnnonsEdit : System.Web.UI.Page
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

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Annons AnnonsEditFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetAnnonsByID(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Annonsen hämtades vid redigering.");
                return null;
            }
        }

        //Id parametern ska matcha samma som på controllen        
        public void AnnonsEditFormView_UpdateItem(int Annonsid)
        {
            try
            {
                var annons = Service.GetAnnonsByID(Annonsid);
                if (annons == null)
                {
                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Annonsen med annonsnummer {0} hittades inte.", Annonsid));
                    return;
                }

                //TryUpdateModel validerar
                if (TryUpdateModel(annons))
                {
                    Service.SaveAnnons(annons);
                    //Skickar meddelande om att annonsen har updaterats
                    Page.SetTempData("SuccessMessage", "Annonsen är updaterad.");
                    //Skickas till annonsen som har updaterats in med hjälp av id
                    Response.RedirectToRoute("AnnonsDetails", new { id = annons.AnnonsID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            //Blev något fel i updateringen så fångas det upp här och precenteras i ValidationSummary
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Annonsen skulle uppdateras.");
            }
        }

        //Hämtar kategorityperna
        public IEnumerable<KategoriTyp> KategoriTypeDropDownList_GetData()
        {
            return Service.GetKategoriTypes();
        }

        //Hämtar läntyperna
        public IEnumerable<LanTyp> LanTypeDropDownList_GetData()
        {
            return Service.GetLanTypes();
        }
    }
}