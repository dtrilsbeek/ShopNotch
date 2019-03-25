using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? ThemeId { get; set; }
        public string Name { get; set; }

        public virtual Theme Theme { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
