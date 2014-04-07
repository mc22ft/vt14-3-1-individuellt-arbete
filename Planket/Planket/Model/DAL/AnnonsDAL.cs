using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Planket.Model.DAL
{
    public class AnnonsDAL : DALBase
    {
        //----------------------------------------------- Hämtar ut alla Annonser ----------------------------------------------
        public IEnumerable<Annons> GetAnnonser()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    //List objekt, plats för 100 ref
                    var annons = new List<Annons>(100);

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("usp_002_Getlist_OrByID_Annons", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var AnnonsIDIndex = reader.GetOrdinal("AnnonsID");
                        var RubrikIndex = reader.GetOrdinal("Rubrik");
                        var PrisIndex = reader.GetOrdinal("Pris");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            annons.Add(new Annons
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                AnnonsID = reader.GetInt32(AnnonsIDIndex),
                                Rubrik = reader.GetString(RubrikIndex),
                                Pris = reader.GetInt32(PrisIndex)
                            });
                        }
                    }

                    //Tar bort det minne som inte används
                    annons.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return annons;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }

        //----------------------------------------------- Hämtar EN Annons ----------------------------------------------
        public Annons GetAnnonsByID(int AnnonsId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("usp_002_Getlist_OrByID_Annons", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den parameter som den lagrade proceduren kärver
                    cmd.Parameters.Add("@AnnonsID", SqlDbType.Int, 4).Value = AnnonsId;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    // skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        var AnnonsIDIndex = reader.GetOrdinal("AnnonsID");
                        var RubrikIndex = reader.GetOrdinal("Rubrik");
                        var BeskrivningIndex = reader.GetOrdinal("Beskrivning");
                        var prisIndex = reader.GetOrdinal("Pris");
                        var LanIDIndex = reader.GetOrdinal("LänID");

                        var KategoriIDIndex = reader.GetOrdinal("KategoriID");

                        //Så länge set finns poster kvar. Annars false
                        if (reader.Read())
                        {
                            return new Annons
                            {
                                //Hämtar ut column innehållet med namn egenskaper 
                                AnnonsID = reader.GetInt32(AnnonsIDIndex),
                                Rubrik = reader.GetString(RubrikIndex),
                                Beskrivning = reader.GetString(BeskrivningIndex),
                                Pris = reader.GetInt32(prisIndex),
                                LanID = reader.GetInt32(LanIDIndex),
                                KategoriID = reader.GetInt32(KategoriIDIndex)                               
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }

        //----------------------------------------------- Lägger till en Annons ----------------------------------------------        
        public void InsertAnnons(Annons annons)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_002_create_Annons", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Rubrik", SqlDbType.VarChar, 50).Value = annons.Rubrik;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 500).Value = annons.Beskrivning;
                    cmd.Parameters.Add("@Pris", SqlDbType.Int, 4).Value = annons.Pris;
                    cmd.Parameters.Add("@KategoriID", SqlDbType.Int, 4).Value = annons.KategoriID;
                    cmd.Parameters.Add("@LanID", SqlDbType.Int, 4).Value = annons.LanID;
                    //
                    cmd.Parameters.Add("@AnnonsID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //Exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Customer-objektet värdet.
                    annons.AnnonsID = (int)cmd.Parameters["@AnnonsID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }

        //----------------------------------------------- Uppdaterar en Annons ----------------------------------------------        
        public void UpdateAnnons(Annons annons)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_002_update_Annons", conn); //Skapa nu update Procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de paramterar den lagrade proceduren kräver
                    cmd.Parameters.Add("@Rubrik", SqlDbType.VarChar, 50).Value = annons.Rubrik;
                    cmd.Parameters["@Rubrik"].Value = annons.Rubrik;
                    cmd.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 500).Value = annons.Beskrivning;
                    cmd.Parameters["@Beskrivning"].Value = annons.Beskrivning;
                    cmd.Parameters.Add("@Pris", SqlDbType.Int, 4).Value = annons.Pris;
                    cmd.Parameters["@Pris"].Value = annons.Pris;
                    //Id
                    cmd.Parameters.Add("@AnnonsID", SqlDbType.Int, 4).Value = annons.AnnonsID;
                    cmd.Parameters["@AnnonsID"].Value = annons.AnnonsID;
                    cmd.Parameters.Add("@LanID", SqlDbType.Int, 4).Value = annons.LanID;
                    cmd.Parameters["@LanID"].Value = annons.LanID;
                    cmd.Parameters.Add("@KategoriID", SqlDbType.Int, 4).Value = annons.KategoriID;
                    cmd.Parameters["@KategoriID"].Value = annons.KategoriID;
                                      
                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //Exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar kategori-objektet värdet.
                    annons.AnnonsID = (int)cmd.Parameters["@AnnonsID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }
        
        //----------------------------------------------- Tar bort EN Annons ----------------------------------------------
        public void DeleteAnnons(int id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_002_delete_Annons", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den parameter som den lagrade proceduren kärver
                    cmd.Parameters.Add("@AnnonsID", SqlDbType.Int, 4).Value = id;

                    //Öppnar anslutningen, databasen
                    conn.Open();


                    //Exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }
    }
}