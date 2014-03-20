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
    public partial class AddEdit : System.Web.UI.Page
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
            //Visar meddelande i ValidationSummary om ModelState får felmeddelande (längre ner)
            if (Session["Success2"] as bool? == true)
            {
                MessagePlaceHolder.Visible = true;
                Session.Remove("Success2");
            }
        }

        //Binder data som ska finns i "textboxarna" på sidan. 
        public Pro2014ASP.Model.Add AddAddsFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetAdd(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Annonsen hämtades vid redigering.");
                return null;
            }
        }

        //Updaterar det som formuläret returnerar
        public void CustomerFormView_UpdateItem(int addID) //Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var add = Service.GetAdd(addID);
                if (add == null)
                {
                    // Hittade inte kunden. (detta är för <%$ Resources:Strings, Validation_Header %> )
                    ModelState.AddModelError(String.Empty,
                        String.Format("Annonsen med annonsnummer {0} hittades inte.", addID));
                    return;
                }

                //TryUpdateModel validerar
                if (TryUpdateModel(add)) 
                {
                    Service.SaveAdd(add);

                    //Vissar meddelande om det gick att spara updateringen
                    Session["Success2"] = true; 
                    Response.RedirectToRoute("AddDetails", new { id = add.AddID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            //Blev något fel i updateringen så fångas det upp här och precenteras i ValidationSummary
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Annonsen skulle uppdateras.");
            }
        }


    }
}