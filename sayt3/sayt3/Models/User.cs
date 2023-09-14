using System;
using System.Collections.Generic;

namespace sayt3.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int UserId { get; set; }
        public string UserAd { get; set; } = null!;
        public string UserSoyad { get; set; } = null!;
        public int? UserStatusId { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual Statuss? UserStatus { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
