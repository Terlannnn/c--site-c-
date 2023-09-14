using System;
using System.Collections.Generic;

namespace sayt3.Models
{
    public partial class Statuss
    {
        public Statuss()
        {
            Users = new HashSet<User>();
        }

        public int StatussId { get; set; }
        public string StatussAd { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
