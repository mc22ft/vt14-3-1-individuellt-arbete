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

        //Hämtar ut alla kontakterna och hämtar uppkopplingen till server
        public IEnumerable<Add> GetAdds()
        {
            //Try catch
            using (var conn = CreateConnection())
            {
                try
                {

                    var add = new List<Add>(100);

                    var cmd = new SqlCommand("AppSchema.usp_01_list", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var annonsIDIndex = reader.GetOrdinal("AnnonsID");
                        var rubrikIndex = reader.GetOrdinal("Rubrik");
                        var prisIndex = reader.GetOrdinal("Pris");
                        var NamnIndex = reader.GetOrdinal("Ort"); //På Län som annons finns i
                        var inlagdIndex = reader.GetOrdinal("Datum");

                        while (reader.Read())
                        {
                            add.Add(new Add
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                AddID = reader.GetInt32(annonsIDIndex),
                                HeadLine = reader.GetString(rubrikIndex),
                                Price = reader.GetInt32(prisIndex),
                                Town = reader.GetString(NamnIndex),
                                Insert = reader.GetDateTime(inlagdIndex)
                            });
                        }
                    }
                    add.TrimExcess();

                    return add;
                }
                catch
                {
                    throw new ApplicationException("Fel fel...");
                }
            }
        }


        //Hämtar ut en contact
        public Add GetAddById(int addID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("AppSchema.usp_04_getbyID", conn);//ändra
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AddID", SqlDbType.Int, 4).Value = addID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {                        

                        if (reader.Read())
                        {

                            var annonsIDIndex = reader.GetOrdinal("AnnonsID");

                            var rubrikIndex = reader.GetOrdinal("Rubrik");
                            var inlagdIndex = reader.GetOrdinal("Datum");
                            var BeskrivningIndex = reader.GetOrdinal("Beskrivning");

                            var prisIndex = reader.GetOrdinal("Pris");
                            var ortIndex = reader.GetOrdinal("Ort"); //På Län som annons finns i

                            var namnIndex = reader.GetOrdinal("Namn");
                            var KontaktIndex = reader.GetOrdinal("Kontakt");

                            ////Som ska finns med när man ska redigera sin annons
                            //var postnrIndex = reader.GetOrdinal("Postnr");
                            ////var lanIDIndex = reader.GetOrdinal("LänID");


                            return new Add
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                AddID = reader.GetInt32(annonsIDIndex),

                                HeadLine = reader.GetString(rubrikIndex),
                                Insert = reader.GetDateTime(inlagdIndex),
                                Description = reader.GetString(BeskrivningIndex),

                                Price = reader.GetInt32(prisIndex),
                                Town = reader.GetString(ortIndex),

                                Name = reader.GetString(namnIndex),
                                Contact = reader.GetString(KontaktIndex)

                                //Postalcode = reader.GetInt32(postnrIndex)
                                ////Area = reader.GetString(lanIDIndex)
                                                               
                            };
                        }
                    }
                    return null;
                }
                catch(Exception e)
                {
                    throw e;
                }
                //catch
                //{
                //    throw new ApplicationException("Fel fel...");
                //}
            }
        }



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


        //Sparar en annons
        internal static void InsertAdd(Add add)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //Kommentarerna nedan är till för senare att återblicka på!!! Sorry Anne :))))

                    // Skapar och initierar ett SqlCommand-objekt som används till att 
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_02_create", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    //cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contactId;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@Namn", SqlDbType.VarChar, 30).Value = add.Name;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 6).Value = add.Postalcode;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = add.Town;

                    cmd.Parameters.Add("@Kontakt", SqlDbType.VarChar, 25).Value = add.Contact;

                    //cmd.Parameters.Add("@Lan", SqlDbType.VarChar, 20).Value = add.Area; 
                    cmd.Parameters.Add("@Rubrik", SqlDbType.VarChar, 50).Value = add.HeadLine;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 500).Value = add.Description;
                    cmd.Parameters.Add("@Pris", SqlDbType.Int, 4).Value = add.Price;
                    
                    //cmd.Parameters.Add("@AddID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Den här parametern är lite speciell. Den skickar inte något data till den lagrade proceduren,
                    // utan hämtar data från den. (Fungerar ungerfär som ref- och out-prameterar i C#.) Värdet 
                    // parametern kommer att ha EFTER att den lagrade proceduren exekverats är primärnycklens värde
                    // den nya posten blivit tilldelad av databasen.


                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    //add.AddID = (int)cmd.Parameters["@AddID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
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
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_05_update", conn); //Skapa nu update Procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.


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

                    // Den lagrade proceduren innehåller en UPDATE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    add.AddID = (int)cmd.Parameters["@AddID"].Value;

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }





        public void DeleteAdd(int id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_03_delete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver. Använder här det effektiva sätttet att
                    // göra det på - något "svårare" men ASP.NET behöver inte "jobba" så mycket.
                    cmd.Parameters.Add("@AnnonsID", SqlDbType.Int, 4).Value = id;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en DELETE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
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