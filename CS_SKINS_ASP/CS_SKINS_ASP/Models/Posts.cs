using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_SKINS_ASP.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int SujetId { get; set; }
        public string Message { get; set; }
        public DateTime DatePublication { get; set; }
        public string Auteur { get; set; }
    }
}