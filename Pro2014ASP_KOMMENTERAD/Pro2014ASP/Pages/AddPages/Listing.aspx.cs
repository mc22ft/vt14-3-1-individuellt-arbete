using Pro2014ASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro2014ASP.Pages.AddPages
{
    public partial class Listing : System.Web.UI.Page
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
            //CancelHyperLink.NavigateUrl = GetRouteUrl("CustomerDetails", null); //Fick det inte att funka
        }
                  
        //Hämtar alla annonser      
        public IEnumerable<Add> AddListView_GetData()
        {
            return Service.GetAdds();
        }
    }
}



//-------------------------------- Bortkommenterad eller sparad kod nedan ---------------------------------


// The return type can be changed to IEnumerable, however to support
// paging and sorting, the following parameters must be added:
//     int maximumRows
//     int startRowIndex
//     out int totalRowCount
//     string sortByExpression
//public IEnumerable<Pro2014ASP.Model.Add> AddListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
//{
//    var dd = Service.GetAddsPageWise(maximumRows, startRowIndex, out totalRowCount);
//    return dd.ToList<Pro2014ASP.Model.Add>();
//}
//public IEnumerable<Pro2014ASP.Model.Add> AddListView_GetData1()
//{
//    int test = 0;
//    var dd = Service.GetAddsPageWise(1, 1, out test);
//    return dd.ToList<Pro2014ASP.Model.Add>();
//}