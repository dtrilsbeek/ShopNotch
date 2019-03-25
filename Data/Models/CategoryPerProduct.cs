using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CategoryPerProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
