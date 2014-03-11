using Pro2014ASP.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro2014ASP.Model
{
    public class Service
    {
        //Fields
        private AddDAL _contactDAL;

        //Properties
        private AddDAL ContactDAL
        {
            //Om contactdal är null gör det till höger om ??
            get { return _contactDAL ?? (_contactDAL = new AddDAL()); }
        }
        public IEnumerable<Add> GetAddsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ContactDAL.GetAddPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
    }
}