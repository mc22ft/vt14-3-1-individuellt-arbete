using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Planket.Model.DAL
{
    public class KategoriDAL : DALBase
    {
        
        //----------------------------------------------- Hämtar ut alla kategorierna ----------------------------------------------
        public IEnumerable<KategoriTyp> GetKategorier()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    //List objekt, plats för 100 ref
                    var kategori = new List<KategoriTyp>(100);

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("AppSchema.usp_001_list_Kategori", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var KategoriIDIndex = reader.GetOrdinal("KategoriID");
                        var KategoriTypIndex = reader.GetOrdinal("KategoriTyp");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            kategori.Add(new KategoriTyp
                                {
                                    //Hämtar ut column innehållet med namn egenskaper
                                    KategoriID = reader.GetInt32(KategoriIDIndex),
                                    Kategorityp = reader.GetString(KategoriTypIndex)
                                });
                        }
                    }

                    //Tar bort det minne som inte används
                    kategori.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return kategori;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }

        //----------------------------------------------- Hämtar ut EN kategorityp ----------------------------------------------
        public KategoriTyp GetKategoriById(int kategoriID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("AppSchema.usp_001_getById_Kategori", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den parameter som den lagrade proceduren kärver
                    cmd.Parameters.Add("@KategoriID", SqlDbType.Int, 4).Value = kategoriID;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    // skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        var KategoriIDIndex = reader.GetOrdinal("KategoriID");
                        var KategoritypIndex = reader.GetOrdinal("Kategorityp");

                        //Så länge set finns poster kvar. Annars false
                        if (reader.Read())
                        {
                            return new KategoriTyp
                            {
                                //Hämtar ut column innehållet med namn egenskaper 
                                KategoriID = reader.GetInt32(KategoriIDIndex),
                                Kategorityp = reader.GetString(KategoritypIndex)                               
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
                
        //----------------------------------------------- Lägger till en kategori ----------------------------------------------        
        public void InsertKategori(KategoriTyp kategori)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {                      
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_001_create_Kategori", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@KategoriTyp", SqlDbType.VarChar, 25).Value = kategori.Kategorityp;                    
                   
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

        //----------------------------------------------- Uppdaterar en kategorityp ----------------------------------------------        
        public void UpdateKategori(KategoriTyp kategori)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_001_update_Kategori", conn); //Skapa nu update Procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add(new SqlParameter("@KategoriTyp", SqlDbType.VarChar, 25));
                    cmd.Parameters["@KategoriTyp"].Value = kategori.Kategorityp;                    

                    //Id
                    cmd.Parameters.Add(new SqlParameter("@KategoriID", SqlDbType.Int, 4));
                    cmd.Parameters["@KategoriID"].Value = kategori.KategoriID;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //Exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar kategori-objektet värdet.
                    kategori.KategoriID = (int)cmd.Parameters["@KategoriID"].Value;

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }

        //----------------------------------------------- Tar bort EN kategorityp ----------------------------------------------
        public void DeleteKategoriTyp(KategoriTyp kategori)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("AppSchema.usp_001_delete_Kategori", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till den parameter som den lagrade proceduren kärver
                    cmd.Parameters.Add("@KategoriID", SqlDbType.Int, 4).Value = kategori.KategoriID;

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