using Planket.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planket.Pages.KategoriPages
{
    public partial class KategoriPage : System.Web.UI.Page
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

        //Hämtar kategorier
        public IEnumerable<KategoriTyp> KategoriListView_GetData()
        {
            return Service.GetKategorier();
        }

        //Sparar en kategori
        public void KategoriListView_InsertItem(KategoriTyp kategori)
        {            
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveKategori(kategori);
                    //Skickar meddelande om att kategori sparades
                    Page.SetTempData("SuccessMessage", "Du har lagt till en kategori.");
                    //Skickas tillbaka till kategori sidan
                    Response.RedirectToRoute("KategoriPage");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception) //Fångar upp om någor gick fel                      
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då en kategori skulle läggas till.");
                }
            }
        }

        // Uppdaterar en Kontakts kategoriuppgifter i databasen.
        // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        public void KategoriListView_UpdateItem(int kategoriID) 
        {
            var kategori = Service.GetKategori(kategoriID);
            
            if (kategori == null)
            {
                // Hittade inte kunden.
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", kategoriID));
                return;
            }

            if (TryUpdateModel(kategori)) //TryUpdateModel validerar
            {
                // sparar kategori
                Service.SaveKategori(kategori);

                //Skickar meddelande om att kategorin updateras
                Page.SetTempData("SuccessMessage", "Du har updaterat en kategori.");
                //Skickas tillbaka till kategori sidan
                Response.RedirectToRoute("KategoriPage");
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void KategoriListView_DeleteItem(KategoriTyp kategori)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.DeleteKategoriTyp(kategori);
                    //Skickar meddelande om att man har rederat en kategori
                    Page.SetTempData("SuccessMessage", "Du har raderat en kategori.");
                    //Skickas tillbaka till kategori sidan
                    Response.RedirectToRoute("KategoriPage");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)//Fångar upp om någor gick fel  
                {
                    ModelState.AddModelError(String.Empty, "Du kan inte ta bort en kategori som finns på en annons.");
                }                                           //Ett oväntat fel inträffade då kunduppgiften skulle tas bort.
            }
        }

        protected void BackToAddAnnonsLinkButton_Click(object sender, EventArgs e)
        {
            //Töma cachen så att den laddas om på nytt när obj lagts till i kategori            
            Cache.Remove("KategoriTypes");

            Service.GetKategoriTypes();
            //Skickas tillbaka till skapa annons
            Response.RedirectToRoute("AnnonsCreate");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}