using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pro2014ASP.Model.DAL
{
    public class AreaTypeDAL : DALBase
    {
         /// <summary>
        /// Hämtar alla kontakttyper i databasen.
        /// </summary>
        ///// <returns>Lista med referenser till ContactType-objekt.</returns>
        //public IEnumerable<AreaType> GetAreaTypes()
        //{
        //    // Skapar ett anslutningsobjekt.
        //    using (var conn = CreateConnection())
        //    {
        //        try
        //        {
        //            // Skapar och initierar ett SqlCommand-objekt som används till att 
        //            // exekveras specifierad lagrad procedur.
        //            var cmd = new SqlCommand("app.uspGetContactTypes", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            // Skapar det List-objekt som initialt har plats för 10 referenser till ContactType-objekt.
        //            List<ContactType> contactTypes = new List<ContactType>(10);

        //            // Öppnar anslutningen till databasen.
        //            conn.Open();

        //            // Den lagrade proceduren innehåller en SELECT-sats som kan returnera flera poster varför
        //            // ett SqlDataReader-objekt måste ta hand om alla poster. Metoden ExecuteReader skapar ett
        //            // SqlDataReader-objekt och returnerar en referens till objektet.
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                // Tar reda på vilket index de olika kolumnerna har. Det är mycket effektivare att göra detta
        //                // en gång för alla innan while-loopen. Genom att använda GetOrdinal behöver du inte känna till
        //                // i vilken ordning de olika kolumnerna kommer, bara vad de heter.
        //                var contactTypeIdIndex = reader.GetOrdinal("ContactTypeId");
        //                var nameIndex = reader.GetOrdinal("Name");
        //                var sortOrderIndex = reader.GetOrdinal("SortOrder");

        //                // Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler 
        //                // poster returnerar Read false.
        //                while (reader.Read())
        //                {
        //                    // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
        //                    // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
        //                    contactTypes.Add(new AreaType
        //                    {
        //                        ContactTypeId = reader.GetInt32(contactTypeIdIndex),
        //                        Name = reader.GetString(nameIndex),
        //                        SortOrder = reader.GetByte(sortOrderIndex)
        //                    });
        //                }
        //            }

        //            // Sätter kapaciteten till antalet element i List-objektet, d.v.s. avallokerar minne
        //            // som inte används.
        //            contactTypes.TrimExcess();

        //            // Returnerar referensen till List-objektet med referenser med ContactType-objekt.
        //            return contactTypes;
        //        }
        //        catch
        //        {
        //            // Kastar ett eget undantag om ett undantag kastas.
        //            throw new ApplicationException(GenericErrorMessage);
        //        }
        //    }
        //}
        ///// <summary>
        ///// Hämtar en kontakttyp.
        ///// </summary>
        ///// <param name="customerId">En kontaktuppgifts nummer.</param>
        ///// <returns>Ett Contact-objekt med en kontaktuppgifter.</returns>
        //public ContactType GetContactTypeById(int contactTypeId)
        //{
        //    // Skapar ett anslutningsobjekt.
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            // Skapar och initierar ett SqlCommand-objekt som används till att 
        //            // exekveras specifierad lagrad procedur.
        //            SqlCommand cmd = new SqlCommand("app.uspGetContactType", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            // Lägger till den paramter den lagrade proceduren kräver. Använder här det MINDRE effektiva 
        //            // sätttet att göra det på - enkelt, men ASP.NET behöver "jobba" rätt mycket.
        //            cmd.Parameters.AddWithValue("@ContactTypeId", contactTypeId);

        //            // Öppnar anslutningen till databasen.
        //            conn.Open();

        //            // Den lagrade proceduren innehåller en SELECT-sats som kan returner en post varför
        //            // ett SqlDataReader-objekt måste ta hand om posten. Metoden ExecuteReader skapar ett
        //            // SqlDataReader-objekt och returnerar en referens till objektet.
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                // Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
        //                // Read false.
        //                if (reader.Read())
        //                {
        //                    // Tar reda på vilket index de olika kolumnerna har. Genom att använda 
        //                    // GetOrdinal behöver du inte känna till i vilken ordning de olika 
        //                    // kolumnerna kommer, bara vad de heter.
        //                    var contactTypeIdIndex = reader.GetOrdinal("ContactTypeId");
        //                    var nameIndex = reader.GetOrdinal("Name");
        //                    var sortOrderIndex = reader.GetOrdinal("SortOrder");

        //                    // Returnerar referensen till de skapade Contact-objektet.
        //                    return new ContactType
        //                    {
        //                        ContactTypeId = reader.GetInt32(contactTypeIdIndex),
        //                        Name = reader.GetString(nameIndex),
        //                        SortOrder = reader.GetByte(sortOrderIndex)
        //                    };
        //                }
        //            }

        //            // Istället för att returnera null kan du välja att kasta ett undatag om du 
        //            // inte får "träff" på en kontaktuppgift. I denna applikation väljer jag att *inte* betrakta 
        //            // det som ett fel om det inte går att hitta en kontaktuppgift. Vad du väljer är en smaksak...
        //            return null;
        //        }
        //        catch
        //        {
        //            // Kastar ett eget undantag om ett undantag kastas.
        //            throw new ApplicationException(GenericErrorMessage);
        //        }
            
        

//    }
//}



    }
}