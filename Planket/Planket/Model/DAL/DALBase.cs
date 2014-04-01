using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Planket.Model.DAL
{
    //DALBase hämtar connection stringen från web.config filen
    public class DALBase
    {
        //Field private statiskt
        private static string _connectionString;

        //Konstruktor statiskt
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["mc22ft_ConnectingString"].ConnectionString;
        }
        //Metod, protekted statisk. returnera
        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}