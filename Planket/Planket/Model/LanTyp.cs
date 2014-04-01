using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planket.Model.DAL
{
    //Län typerna
    public class LanTyp
    {
        public int LanID { get; set; }

        [Required(ErrorMessage = "Ett län måste anges!")]
        [StringLength(20, ErrorMessage = "Du kan inte ange mer än 20 tecken!")]
        public string Lantyp { get; set; }

    }
}