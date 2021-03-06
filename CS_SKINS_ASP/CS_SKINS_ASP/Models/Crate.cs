﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Crate
    {
        public int ID { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Crates.ResourceCrate), Name = "Nom")]
        public string Nom { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Crates.ResourceCrate), Name = "Prix")]
        public float Prix { get; set; }
        public ICollection<Skins> Skins { get; set; }
        public string ImageNom { get; set; }
        public string ImageType { get; set; }
        public int ImageTaille { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }
    }
}