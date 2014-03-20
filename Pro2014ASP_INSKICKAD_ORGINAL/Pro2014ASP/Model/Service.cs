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
        //Fields
        private AddDAL _addDAL;
        //private AreaTypeDAL _areaTypeDAL;
        //Properties
        private AddDAL AddDAL
        {
            //Om contactdal är null gör det till höger om ??
            get { return _addDAL ?? (_addDAL = new AddDAL()); }
        }
        //private AreaTypeDAL AreaTypeDAL
        //{
        //    get { return _areaTypeDAL ?? (_areaTypeDAL = new AreaTypeDAL()); }
        //}


        public IEnumerable<Add> GetAdds()
        {
            return AddDAL.GetAdds();
        }

        //Hämtar en Annons
        public Add GetAdd(int id)
        {
            return AddDAL.GetAddById(id);
        }

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


        //Sparar en annons och anv och updaterar
        public void SaveAdd(Add add)
        {
            //Anropar extension method
            ICollection<ValidationResult> validationResults;
            if (!add.Validate(out validationResults))
            {
                var ex = new ValidationException("");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }                        

            //insert och update
            if (add.AddID == 0)
            {
                AddDAL.InsertAdd(add);
            }
            else
            {
                AddDAL.UpdateAdd(add);
            }           
        }

        public void DeleteAdd(int id)
        {
            AddDAL.DeleteAdd(id);
        }
    }
}


