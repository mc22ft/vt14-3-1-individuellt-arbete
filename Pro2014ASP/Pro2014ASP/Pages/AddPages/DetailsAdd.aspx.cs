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
                
                Session.Remove("Success2");
            }
        }
        
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
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

        // The id parameter name should match the DataKeyNames value set on the control
     
        protected void DeleteLinkButton_Command1(object sender, CommandEventArgs e)
        {
            if (ModelState.IsValid) //ModelState.IsValid = när man jobbar med data annotation(bindning)
            {
                try
                {
                    var id = int.Parse(e.CommandArgument.ToString());

                    Service.DeleteAdd(id);
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