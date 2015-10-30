using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class AspNetUserInfoSup
    {
        //[Key]
        public string ID { get; set; }
        public DateTime DateInscription { get; set; }
        public string IdentifiantCSSKINS { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
    }
}