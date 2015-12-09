using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int SujetId { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Posts.ResourcePost), Name = "Message")]
        public string Message { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Posts.ResourcePost), Name = "datePub")]
        public DateTime DatePublication { get; set; }
        [Display(ResourceType = typeof(CS_SKINS_ASP.Views.Posts.ResourcePost), Name = "Auteur")]
        public string Auteur { get; set; }
    }
}