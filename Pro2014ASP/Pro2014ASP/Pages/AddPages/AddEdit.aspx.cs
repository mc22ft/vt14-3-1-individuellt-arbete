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
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Success2"] as bool? == true)
            {
                MessagePlaceHolder.Visible = true;
                Session.Remove("Success2");
            }
        }


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

        public void CustomerFormView_UpdateItem(int addID) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var add = Service.GetAdd(addID);
                if (add == null)
                {
                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Annonsen med annonsnummer {0} hittades inte.", addID));
                    return;
                }

                if (TryUpdateModel(add)) //TryUpdateModel validerar
                {
                    Service.SaveAdd(add);

                    Session["Success2"] = true;
                    Response.RedirectToRoute("AddDetails", new { id = add.AddID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Annonsen skulle uppdateras.");
            }
        }


    }
}