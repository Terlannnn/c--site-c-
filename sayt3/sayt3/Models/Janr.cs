using System;
using System.Collections.Generic;

namespace sayt3.Models
{
    public partial class Janr
    {
        public Janr()
        {
            Kitabs = new HashSet<Kitab>();
        }

        public int JanrId { get; set; }
        public string? JanrAd { get; set; }

        public virtual ICollection<Kitab> Kitabs { get; set; }
    }
}
