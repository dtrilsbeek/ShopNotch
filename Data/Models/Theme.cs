using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Theme
    {
        public Theme()
        {
            Shop = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Settings { get; set; }

        public virtual ICollection<Shop> Shop { get; set; }
    }
}
