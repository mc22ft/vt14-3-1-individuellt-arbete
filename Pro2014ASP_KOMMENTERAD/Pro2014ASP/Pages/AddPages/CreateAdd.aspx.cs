using Pro2014ASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pro2014ASP
{
    public partial class CreateAdd : System.Web.UI.Page
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
            if (Session["Success"] as bool? == true)
            {
                MessagePlaceHolder.Visible = true;
                Session.Remove("Success");
            }
        }

        //Skickar och sparar annonsen
        public void CreateAddListView_InsertItem(Add add)
        {
            //ModelState.IsValid = när man jobbar med data annotation(bindning) Medd till aspx
            if (ModelState.IsValid) 
            {
                try
                {
                    Service.SaveAdd(add);
                    Session["Success"] = true;
                    //Response.Redirect("~/Default.aspx");
                    //Page.SetTempData("SuccessMessage", Strings.Action_Contact_Saved); //medd precenteras med en sträng ej ModelState
                    Response.RedirectToRoute("Listing", new { id = add.AddID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)                     
                {
                    //Skickar en sträng till ValidationSummary om den hade varit formateras på det sättet
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle läggas till.");
                }
            }           
        }
    }
}


//-------------------------------- Bortkommenterad eller sparad kod nedan ---------------------------------

////Dubbla meddelande kommer fram!!!! TILLHÖR gamla valederingen!!!!!
////Detta är från Mats, blir lite dubbel föreläsning
//var validationResults = ex.Data["ValidationResults"] as IEnumerable<ValidationResult>;
//if (validationResults != null && validationResults.Any()) //Om inte är null så finns det information
//{
//    foreach (var validationResult in validationResults) //Loopar igenom felmeddelande Och det kan finnas fler meddelnade i meddellande
//    {
//        foreach (var memberName in validationResult.MemberNames)
//        {
//            ModelState.AddModelError(memberName, validationResult.ErrorMessage);
//        }
//    }
//}

//protected void AreaListView_ItemDataBound(object sender, ListViewItemEventArgs e)
//{
//    var label = e.Item.FindControl("AreaTypeNameLabel") as Label;
//    if (label != null)
//    {
//        // Typomvandlar e.Item.DataItem så att primärnyckelns värde kan hämtas och...
//        var contact = (Add)e.Item.DataItem;

//        // ...som sedan kan användas för att hämta ett ("cachat") kontakttypobjekt...
//        var contactType = Service.GetAreaTypes()
//            .Single(ct => ct.AreaTypeId == area.AreaTypeId);

//        // ...så att en beskrivning av kontaktypen kan presenteras; ex: Arbete: 012-345 67 89
//        //label.Text = String.Format(label.Text, areaType.Name);
//    }
//}



//public IEnumerable<AreaType> ContactTypeDropDownList_GetData()
//{
//    return Service.GetAreaTypes();
//}