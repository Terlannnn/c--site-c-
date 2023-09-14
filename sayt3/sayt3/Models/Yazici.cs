using System;
using System.Collections.Generic;

namespace sayt3.Models
{
    public partial class Yazici
    {
        public Yazici()
        {
            Kitabs = new HashSet<Kitab>();
        }

        public int YaziciId { get; set; }
        public string YaziciAd { get; set; } = null!;

        public virtual ICollection<Kitab> Kitabs { get; set; }
    }
}
