using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pro2014ASP.Model
{
    public class Add //(annons)
    {
        //Aoutinplementerade Egenskaper med Valedering
        public int AddID { get; set; } //Behövs inte valideraas 
 
        [Required(ErrorMessage = "En rubrik måste anges!")]
        [StringLength(50, ErrorMessage = "Du kan inte ange mer än 50 tecken!")]
        public string HeadLine {get; set;}
        
        [Required(ErrorMessage = "En pris måste anges!")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Du har anget ett falaktig pris!")]
        public int Price {get; set; }
        
        public DateTime Insert {get; set;} //Default från server, kommer inte anges i applikationen
                
        //public string Area { get; set; } //Län = Meningen att det ska va en dropdown

        [Required(ErrorMessage = "En namn måste anges!")]
        [StringLength(30, ErrorMessage = "Du kan inte ange mer än 30 tecken!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ett postnummer måste anges!")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Du har anget ett falaktig postnummer!")]
        public int Postalcode { get; set; }

        [Required(ErrorMessage = "En stad måste anges!")]
        [StringLength(25, ErrorMessage = "Du kan inte ange mer än 25 tecken!")]
        public string Town { get; set; }

        [Required(ErrorMessage = "En kontakt måste anges!")]
        [StringLength(25, ErrorMessage = "Du kan inte ange mer än 25 tecken!")]
        public string Contact { get; set; }

        [StringLength(500, ErrorMessage = "Du kan inte ange mer än 500 tecken!")]
        public string Description { get; set; }


       
    }
}