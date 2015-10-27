using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class ForumViewModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public string Dernier { get; set; }
        public int NbrPublications { get; set; }
    }
}