using System;
using System.Collections.Generic;
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
    }
}