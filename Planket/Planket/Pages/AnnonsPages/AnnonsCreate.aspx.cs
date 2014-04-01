using Planket.Model;
using Planket.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planket.Pages.AnnonsPages
{
    public partial class AnnonsCreate : System.Web.UI.Page
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

        public void CreateAnnonsFormView_InsertItem(Annons annons)
        {            
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveAnnons(annons);
                    //Skickar meddelande om att annonsen sparades
                    Page.SetTempData("SuccessMessage", "Du har nu lagt in denna annons på Planket.");
                    //Skickas till annonsen som har lagts in med hjälp av id
                    Response.RedirectToRoute("AnnonsDetails", new { id = annons.AnnonsID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)  //Fångar upp om någor gick fel               
                {                    
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då annonsen skulle läggas till.");
                }

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