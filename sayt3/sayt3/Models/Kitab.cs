using System;
using System.Collections.Generic;

namespace sayt3.Models
{
    public partial class Kitab
    {
        public Kitab()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int KitabId { get; set; }
        public string KitabAd { get; set; } = null!;
        public string KitabMelumat { get; set; } = null!;
        public int? KitabQiymet { get; set; }
        public int? KitabYaziciId { get; set; }
        public int? KitabJanrId { get; set; }
        public string? KitabSekil { get; set; }

        public virtual Janr? KitabJanr { get; set; }
        public virtual Yazici? KitabYazici { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
