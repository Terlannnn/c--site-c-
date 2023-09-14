using System;
using System.Collections.Generic;

namespace sayt3.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int? FavoriteUserId { get; set; }
        public int? FavoriteKitabId { get; set; }

        public virtual Kitab? FavoriteKitab { get; set; }
        public virtual User? FavoriteUser { get; set; }
    }
}
