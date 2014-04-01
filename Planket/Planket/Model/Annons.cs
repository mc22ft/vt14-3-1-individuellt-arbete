using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planket.Model
{
    //Annons
    public class Annons
    {

        public int AnnonsID { get; set; }

        [Required(ErrorMessage = "En rubrik måste anges!")]
        [StringLength(50, ErrorMessage = "Du kan inte ange mer än 50 tecken!")]
        public string Rubrik { get; set; }

        [Required(ErrorMessage = "En beskrivning måste anges!")]
        [StringLength(500, ErrorMessage = "Du kan inte ange mer än 500 tecken!")]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "En pris måste anges!")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Du har anget ett falaktig pris!")]
        public int Pris { get; set; }

        public int LanID { get; set; }
        public int KategoriID { get; set; }
        
        
              
        //Valedering behövs ej, read only
        //Anv för att binda namnet till AnnonsDetails (hittade inget annat sätt just då)
        public string KategoriNamn { get; set; }
        public string LanNamn { get; set; }
        

    }
}