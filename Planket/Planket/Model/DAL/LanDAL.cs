using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Planket.Model.DAL
{
    public class LanDAL : DALBase

    {
        //----------------------------------------------- Hämtar ut alla Län typerna ----------------------------------------------
        public IEnumerable<LanTyp> GetLanTypes()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    //List objekt, plats för 30 ref
                    var lan = new List<LanTyp>(30);

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("AppSchema.usp_003_list_Lan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var LanIDIndex = reader.GetOrdinal("LänID");
                        var NamnTypIndex = reader.GetOrdinal("Namn");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            lan.Add(new LanTyp
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                LanID = reader.GetInt32(LanIDIndex),
                                Lantyp = reader.GetString(NamnTypIndex)
                            });
                        }
                    }

                    //Tar bort det minne som inte används
                    lan.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return lan;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }
    }
}