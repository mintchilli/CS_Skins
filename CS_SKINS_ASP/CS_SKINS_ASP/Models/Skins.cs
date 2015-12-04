using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Skins
    {
        public int ID { get; set; }
        public int CrateId { get; set; }
        public float Prix { get; set; }
        public float Probabilité { get; set; }
        public string Rang { get; set; }
        public string ImageNom { get; set; }
        public string ImageType { get; set; }
        public int ImageTaille { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }
    }
}