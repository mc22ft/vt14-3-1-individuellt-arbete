using Planket.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planket.Model
{
    public class Service
    {
        //Privata fält för DAL klasserna
        private KategoriDAL _kategoriDAL;
        private AnnonsDAL _annonsDAL;
        private LanDAL _lanDAL;

        //Properties
        private KategoriDAL KategoriDAL
        {
            //Om contactdal är null gör det till höger om ??
            get { return _kategoriDAL ?? (_kategoriDAL = new KategoriDAL()); }
        }
        private AnnonsDAL AnnonsDAL
        {
            get { return _annonsDAL ?? (_annonsDAL = new AnnonsDAL()); }
        }
        private LanDAL LanDAL
        {
            get { return _lanDAL ?? (_lanDAL = new LanDAL()); }
        }


        //Metoder KATEGORITYP
        //Hämtar ALLA Kategorier
        public IEnumerable<KategoriTyp> GetKategorier()
        {
            return KategoriDAL.GetKategorier();
        }

        //Hämtar EN kategori
        public KategoriTyp GetKategori(int kategoriId)
        {
            return KategoriDAL.GetKategoriById(kategoriId);
        }

        //Sparar en kategori el updaterar en kontakt
        public void SaveKategori(KategoriTyp kategori)
        {
            //Valedering
            GetValidation((KategoriTyp)kategori);
            
            //insert eller update
            if (kategori.KategoriID == 0)
            {
                KategoriDAL.InsertKategori(kategori);
            }
            else
            {
                KategoriDAL.UpdateKategori(kategori);
            }      
        }

        //Tar bort en kategori
        public void DeleteKategoriTyp(KategoriTyp kategori)
        {        
            KategoriDAL.DeleteKategoriTyp(kategori);
        }


        //--------- Metoder ANNONSER ----------

        //Hämta annonser
        public IEnumerable<Annons> GetAnnonser()
        {
            return AnnonsDAL.GetAnnonser();
        }

        //Hämta EN med id annons
        public Annons GetAnnonsByID(int AnnonsId)
        {
            return AnnonsDAL.GetAnnonsByID(AnnonsId);
        }

        //spara en annons el updaterar en annons
        public void SaveAnnons(Annons annons)
        {
            //Valedering
            GetValidation((Annons) annons);

            //insert eller update
            if (annons.AnnonsID == 0)
            {
                AnnonsDAL.InsertAnnons(annons);
            }
            else
            {
                AnnonsDAL.UpdateAnnons(annons);
            }
        }

        //Tar bort en annons
        public void DeleteAnnons(int id)
        {
            AnnonsDAL.DeleteAnnons(id);
        }


        //KATEGORITYPER CACHNING
        /// Hämtar alla kontakttyper.       
        /// <returns>Ett List-objekt innehållande referenser till ContactType-objekt.</returns>
        public IEnumerable<KategoriTyp> GetKategoriTypes(bool refresh = false)
        {
            // Försöker hämta lista med kontakttyper från cachen.
            var kategoriTypes = HttpContext.Current.Cache["KategoriTypes"] as IEnumerable<KategoriTyp>;

            // Om det inte finns det en lista med kontakttyper...
            if (kategoriTypes == null || refresh)
            {
                // ...hämtar då lista med kontakttyper...
                kategoriTypes = KategoriDAL.GetKategorier();

                // ...och cachar dessa. List-objektet, inklusive alla ContactType-objekt, kommer att cachas 
                // under 10 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("KategoriTypes", kategoriTypes, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
                      
            // Returnerar listan med kontakttyper.
            return kategoriTypes;
        }

        //LÄNTYPER CACHNING
        //Hämtar lantyperna och lägger dom i cachen
        public IEnumerable<LanTyp> GetLanTypes(bool refresh = false)
        {
            // Försöker hämta lista med lantyper från cachen.
            var LanTypes = HttpContext.Current.Cache["LanTypes"] as IEnumerable<LanTyp>;

            // Om det inte finns det en lista med lantyper...
            if (LanTypes == null || refresh)
            {
                // ...hämtar då lista med lantyper...
                LanTypes = LanDAL.GetLanTypes();

                // ...och cachar dessa. List-objektet, inklusive alla ContactType-objekt, kommer att cachas 
                // under 10 minuter, varefter de automatiskt avallokeras från webbserverns primärminne.
                HttpContext.Current.Cache.Insert("LanTypes", LanTypes, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
            
            // Returnerar listan med lantyper.
            return LanTypes;
        }

        //Valedering av objekten 
        public void GetValidation(Object obj)
        {
            //Anropar extension method. Valedering
            ICollection<ValidationResult> validationResults;
            if (!obj.Validate(out validationResults))
            {
                var ex = new ValidationException("");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
        }
       
    }
}