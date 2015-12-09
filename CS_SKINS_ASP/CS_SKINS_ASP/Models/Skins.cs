using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Skins
    {
        public int ID { get; set; }
        public int CrateId { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Skins.ResourceSkin), Name = "Prix")]
        public float Prix { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Skins.ResourceSkin), Name = "Probabilite")]
        public float Probabilité { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Skins.ResourceSkin), Name = "Rang")]
        public string Rang { get; set; }
        public string ImageNom { get; set; }
        public string ImageType { get; set; }
        public int ImageTaille { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }
    }
}