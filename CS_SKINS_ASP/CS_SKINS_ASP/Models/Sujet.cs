using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Sujet
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Sujets.ResourceSujet), Name = "Titre")]
        public string Titre { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Sujets.ResourceSujet), Name = "Description")]
        public string Description { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Sujets.ResourceSujet), Name = "Auteur")]
        public string Auteur { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Sujets.ResourceSujet), Name = "Dernier")]
        public string Dernier { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Sujets.ResourceSujet), Name = "NombrePost")]
        public string NombrePosts { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }

    }
}