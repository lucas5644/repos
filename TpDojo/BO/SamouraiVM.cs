using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BO
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? ArmeId { get; set; }
        public List<SelectListItem> ArtMartiaux { get; set; } = new List<SelectListItem>();
        public List<int?> ArtMartialIds { get; set; } = new List<int?>();

    }
}
