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

        //Hämtar ut alla annonserna och hämtar uppkopplingen till server
        public IEnumerable<Add> GetAdds()
        {
            //Skapar anslutnings objekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //Plats för 100 ref till AddType objekt
                    var add = new List<Add>(100);

                    //Initierar den lagrade proceduren
                    var cmd = new SqlCommand("AppSchema.usp_01_list", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen (databasen)
                    conn.Open();

                    //Hämtar ut posterna som reader objektet tar hand om
                    using (var reader = cmd.ExecuteReader())
                    {
                        var annonsIDIndex = reader.GetOrdinal("AnnonsID");
                        var rubrikIndex = reader.GetOrdinal("Rubrik");
                        var prisIndex = reader.GetOrdinal("Pris");
                        var NamnIndex = reader.GetOrdinal("Ort");
                        var inlagdIndex = reader.GetOrdinal("Datum");
                        
                        while (reader.Read())
                        {
                            add.Add(new Add
                            {
                                //Hämtar data - Måste veta data typen i sql sastsen
                                AddID = reader.GetInt32(annonsIDIndex),
                                HeadLine = reader.GetString(rubrikIndex),
                                Price = reader.GetInt32(prisIndex),
                                Town = reader.GetString(NamnIndex),
                                Insert = reader.GetDateTime(inlagdIndex)
                            });
                        }
                    }

                    //Raderar det minne som inte behövs
                    add.TrimExcess();

                    //Returnerar ref till list obj. Med ref till AddType objekt
                    return add;
                }
                catch
                {
                    //Kastar undantag med eget felmeddelande
                    throw new ApplicationException("Fel fel...");
                }
            }
        }


        //Hämtar ut en annons
        public Add GetAddById(int addID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Initsierar den lagrade proceduren
                    var cmd = new SqlCommand("AppSchema.usp_04_getbyID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den paramerter den lagrade proceduren kräver
                    cmd.Parameters.Add("@AddID", SqlDbType.Int, 4).Value = addID;

                    //Öppnar anslutningen (databasen)
                    conn.Open();

                    //ExecuteReader skapar ett SqlDataReader-objekt och returnerar en ref till obj
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Finns ingea poster, returneras false
                        if (reader.Read())
                        {
                            //Tar reda på index, GetOrdinal gör så du inte behöver veta ordningen, bara vad kolumnerna heter.
                            var annonsIDIndex = reader.GetOrdinal("AnnonsID");

                            var rubrikIndex = reader.GetOrdinal("Rubrik");
                            var inlagdIndex = reader.GetOrdinal("Datum");
                            var BeskrivningIndex = reader.GetOrdinal("Beskrivning");

                            var prisIndex = reader.GetOrdinal("Pris");
                            var ortIndex = reader.GetOrdinal("Ort"); 

                            var namnIndex = reader.GetOrdinal("Namn");
                            var KontaktIndex = reader.GetOrdinal("Kontakt");

                            return new Add
                            {
                                //Hämtar data - Måste veta data typen i sql sastsen
                                AddID = reader.GetInt32(annonsIDIndex),

                                HeadLine = reader.GetString(rubrikIndex),
                                Insert = reader.GetDateTime(inlagdIndex),
                                Description = reader.GetString(BeskrivningIndex),

                                Price = reader.GetInt32(prisIndex),
                                Town = reader.GetString(ortIndex),

                                Name = reader.GetString(namnIndex),
                                Contact = reader.GetString(KontaktIndex)
                            
                            };
                        }
                    }
                    return null;
                } //Hämta ut detaljer om fel som uppstår genom e i detta fall
                catch(Exception e)
                {
                    throw e;
                }
                //catch
                //{
                        //Kastar undantag med eget felmeddelande
                //    throw new ApplicationException("Fel fel...");
                //}
            }
        }



        //Sparar en annons
        internal static void InsertAdd(Add add)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    //Initsierar den lagrade proceduren
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_02_create", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver
                    cmd.Parameters.Add("@Namn", SqlDbType.VarChar, 30).Value = add.Name;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 6).Value = add.Postalcode;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = add.Town;

                    cmd.Parameters.Add("@Kontakt", SqlDbType.VarChar, 25).Value = add.Contact;

                    cmd.Parameters.Add("@Rubrik", SqlDbType.VarChar, 50).Value = add.HeadLine;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 500).Value = add.Description;
                    cmd.Parameters.Add("@Pris", SqlDbType.Int, 4).Value = add.Price;                
                   
                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren. (INSERT sats i Lproceduren)
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //Kastar undantag med eget felmeddelande
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }           
        }
        //Uppdaterar en anv och annons
        public void UpdateAdd(Add add)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //Initsierar den lagrade proceduren
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_05_update", conn); //Skapa nu update Procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver
                    cmd.Parameters.Add(new SqlParameter("@Rubrik", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Rubrik"].Value = add.HeadLine;

                    cmd.Parameters.Add(new SqlParameter("@Datum", SqlDbType.DateTime));
                    cmd.Parameters["@Datum"].Value = add.Insert;

                    cmd.Parameters.Add(new SqlParameter("@Beskrivning", SqlDbType.VarChar, 500));
                    cmd.Parameters["@Beskrivning"].Value = add.Description;

                    cmd.Parameters.Add(new SqlParameter("@Pris", SqlDbType.Int, 4));
                    cmd.Parameters["@Pris"].Value = add.Price;
                    cmd.Parameters.Add(new SqlParameter("@Ort", SqlDbType.VarChar, 25));
                    cmd.Parameters["@Ort"].Value = add.Town;

                    cmd.Parameters.Add(new SqlParameter("@Namn", SqlDbType.VarChar, 30));
                    cmd.Parameters["@Namn"].Value = add.Name;
                    cmd.Parameters.Add(new SqlParameter("@Kontakt", SqlDbType.VarChar, 25));
                    cmd.Parameters["@Kontakt"].Value = add.Contact;  

                    //Id
                    cmd.Parameters.Add(new SqlParameter("@AddID", SqlDbType.Int, 4));
                    cmd.Parameters["@AddID"].Value = add.AddID;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // ExecuteNonQuery används för att exekvera den lagrade proceduren. (UPDATE sats i Lproceduren)
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Add-objektet värdet.
                    add.AddID = (int)cmd.Parameters["@AddID"].Value;

                }
                catch
                {
                    //Kastar undantag med eget felmeddelande
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        //Tar bort en annons
        public void DeleteAdd(int id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //Initsierar den lagrade proceduren
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_03_delete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.Add("@AnnonsID", SqlDbType.Int, 4).Value = id;

                    // Öppnar anslutningen till databasen.
                    conn.Open();
                    
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren. (innenhåller en DELETE sats, därav ExecuteNonQuery används)
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}



//-------------------------- Sparatd/undan kommenterad kod till senare tillfälle -------------------------------




////  OBS OBS IN MED SORTERINGS parameter
//internal IEnumerable<Add> GetAddPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
//{

//    totalRowCount = 0;
//    //Try catch
//    using (var conn = CreateConnection())
//    {
//        try
//        {
//            var adds = new List<Add>(100);

//            //Programmability.Stored Procedures.AppSchema.usp_GetListOfAdds
//            //Lagrade proceduren in här
//            var cmd = new SqlCommand("AppSchema.usp_GetListOfAdds", conn);
//            cmd.CommandType = CommandType.StoredProcedure;

//            //Info på sidan 431 i boken
//            //cmd.Parameters.Add("@PageIndex", SqlDbType.VarChar, 4).Value = startRowIndex / maximumRows + 1;
//            //cmd.Parameters.Add("@PageSize", SqlDbType.VarChar, 4).Value = maximumRows;
//            //cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;


//            conn.Open();
//            //cmd.ExecuteNonQuery();

//            //totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;

//            using (var reader = cmd.ExecuteReader())
//            {
//                var annonsIDIndex = reader.GetOrdinal("AnnonsID");
//                var rubrikIndex = reader.GetOrdinal("Rubrik");
//                var prisIndex = reader.GetOrdinal("Pris");
//                var NamnIndex = reader.GetOrdinal("Namn"); //På Län som annons finns i
//                var inlagdIndex = reader.GetOrdinal("Datum");

//                while (reader.Read())
//                {
//                    adds.Add(new Add
//                    {
//                        //Hämtar ut column innehållet med namn egenskaper
//                        AddID = reader.GetInt32(annonsIDIndex),
//                        HeadLine = reader.GetString(rubrikIndex),
//                        Price = reader.GetInt32(prisIndex),
//                        Area = reader.GetString(NamnIndex),
//                        Insert = reader.GetDateTime(inlagdIndex)
//                    });
//                }
//            }
//           // adds.TrimExcess();

//            return adds;   //I boken returnerar dom en array
//        }
//        catch(Exception e)
//        {
//            throw e;
//        }
//    }
//}