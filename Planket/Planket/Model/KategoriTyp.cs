using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planket.Model
{
    //Kategorityperna
    public class KategoriTyp
    {
        public int KategoriID { get; set; }
        
        [StringLength(20, ErrorMessage = "Du kan inte ange mer än 20 tecken!")]
        public string Kategorityp { get; set; }
    }
}