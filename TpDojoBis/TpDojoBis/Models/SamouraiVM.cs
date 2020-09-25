using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpDojoBis.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get;set; }
        public List<Arme> Armes { get; set; }
        public int? ArmeId { get; set; }
        public List<ArtMartial> ArtMartiaux { get; set; } = new List<ArtMartial>();
        public List<int> ArtMartiauxIds { get; set; } = new List<int>();
    }
}