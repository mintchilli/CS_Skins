using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Sujet
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DatePublication { get; set; }
        public DateTime DateDernierPost { get; set; }
        public string Auteur { get; set; }
        public string Dernier { get; set; }
        public string NombrePosts { get; set; }

    }
}