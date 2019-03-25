using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Product
    {
        public Product()
        {
            CategoryPerProduct = new HashSet<CategoryPerProduct>();
            ProductPerOrder = new HashSet<ProductPerOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Sku { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public virtual ICollection<CategoryPerProduct> CategoryPerProduct { get; set; }
        public virtual ICollection<ProductPerOrder> ProductPerOrder { get; set; }
    }
}
