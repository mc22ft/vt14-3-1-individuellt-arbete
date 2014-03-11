using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pro2014ASP.Model.DAL
{
    public class AddDAL : DALBase
    {
        //  OBS OBS IN MED SORTERINGS parameter
        internal IEnumerable<Add> GetAddPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            //Try catch
            using (var conn = CreateConnection())
            {
                try
                {
                    var adds = new List<Add>(100);
                    //Programmability.Stored Procedures.AppSchema.usp_GetListOfAdds
                    //Lagrade proceduren in här
                    var cmd = new SqlCommand("AppSchema.usp_GetListOfAdds", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Info på sidan 431 i boken
                    cmd.Parameters.Add("@PageIndex", SqlDbType.VarChar, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.VarChar, 4).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;


                    conn.Open();
                    cmd.ExecuteNonQuery();

                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var annonsIDIndex = reader.GetOrdinal("AnnonsID");
                        var rubrikIndex = reader.GetOrdinal("Rubrik");                        
                        var prisIndex = reader.GetOrdinal("Pris");
                        var NamnIndex = reader.GetOrdinal("Namn"); //På Län som annons finns i
                        var inlagdIndex = reader.GetOrdinal("Datum");

                        while (reader.Read())
                        {
                            adds.Add(new Add
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                AddID = reader.GetInt32(annonsIDIndex),
                                HeadLine = reader.GetString(rubrikIndex),                                
                                Price = reader.GetString(prisIndex),
                                Area = reader.GetString(NamnIndex),
                                Insert = reader.GetDateTime(inlagdIndex)
                            });
                        }
                    }
                    adds.TrimExcess();

                    return adds;   //I boken returnerar dom en array
                }
                catch
                {
                    throw new ApplicationException("Fel fel...");
                }
            }
        }
    }
}