using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Pro2014ASP.Model.DAL
{
    public class DALBase
    {
        //Fält 
        private static string _connectionString;

        //Konstruktor - Hämtar kontaktsträngen från web config
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["mc22ft_ConnectingString"].ConnectionString;
        }
        //Metod
        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}