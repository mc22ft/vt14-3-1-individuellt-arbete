using Planket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planket.Pages.AnnonsPages
{
    public partial class AnnonsList : System.Web.UI.Page
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

        //Hämtar annonser
        public IEnumerable<Annons> AddListView_GetData()
        {
            return Service.GetAnnonser();
        }    
    }
}