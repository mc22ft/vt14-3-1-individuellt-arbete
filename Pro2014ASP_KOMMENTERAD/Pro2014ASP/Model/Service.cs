using Pro2014ASP.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pro2014ASP.Model
{
    public class Service
    {
        //Fält
        private AddDAL _addDAL;
       
        //Egenskap
        private AddDAL AddDAL
        {
            //Om adddal är null gör det till höger om ??
            get { return _addDAL ?? (_addDAL = new AddDAL()); }
        }
      
        //Metoder

        //Hämtar ALLA annonser (lista)
        public IEnumerable<Add> GetAdds()
        {
            return AddDAL.GetAdds();
        }

        //Hämtar EN Annons
        public Add GetAdd(int id)
        {
            return AddDAL.GetAddById(id);
        }

        //Sparar en annons (anv och kontakt) ELLER Updaterar en annons.
        public void SaveAdd(Add add)
        {
            //Anropar extension method - VALIDERING
            // Uppfyller inte objektet affärsreglerna
            ICollection<ValidationResult> validationResults;
            //Returnerar true eller false beroende på om valideringen klaras
            if (!add.Validate(out validationResults)) 
            {
                var ex = new ValidationException(""); //In med ett meddelande om att det inte klarade valideringen
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }                        

            //Om det inte finns ett id så skapas en annons
            if (add.AddID == 0)
            {
                AddDAL.InsertAdd(add);
            }
            else //Om det finns ett id så updateras annons
            {
                AddDAL.UpdateAdd(add);
            }           
        }

        //Tar bort annons
        public void DeleteAdd(int id)
        {
            AddDAL.DeleteAdd(id);
        }
    }
}



//-------------------------- Sparatd/undan kommenterad kod till senare tillfälle -------------------------------



///// <summary>
///// Hämtar alla kontakttyper.
///// </summary>
///// <returns>Ett List-objekt innehållande referenser till ContactType-objekt.</returns>
//public IEnumerable<AreaType> GetAreaTypes(bool refresh = false)
//{
//    // Försöker hämta lista med kontakttyper från cachen.
//    var areaTypes = HttpContext.Current.Cache["AreaTypes"] as IEnumerable<AreaType>;

//    // Om det inte finns det en lista med kontakttyper...
//    if (areaTypes == null || refresh)
//    {
//        // ...hämtar då lista med kontakttyper...
//        areaTypes = AreaTypeDAL.GetAreaTypes();

//        // ...och cachar dessa. List-objektet, inklusive alla ContactType-objekt, kommer att cachas 
//        // under 10 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
//        HttpContext.Current.Cache.Insert("AreaTypes", areaTypes, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
//    }

//    // Returnerar listan med kontakttyper.
//    return areaTypes;
//}



//public IEnumerable<Add> GetAddsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
//{
//    return ContactDAL.GetAddPageWise(maximumRows, startRowIndex, out totalRowCount);
//}
