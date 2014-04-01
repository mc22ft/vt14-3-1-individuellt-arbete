using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Optimization;

namespace Planket.Pages.Shered
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Meddelande om något har ändrats presenteras här            
            SuccessLabel.Text = Page.GetTempData("SuccessMessage") as String;
            SuccessPanel.Visible = !String.IsNullOrWhiteSpace(SuccessLabel.Text);
        }
    }
}