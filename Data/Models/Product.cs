using System;
using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Models
{
    public partial class Product : IEntity
    {
        public Product()
        {
            CategoryPerProduct = new HashSet<CategoryPerProduct>();
            ProductPerOrder = new HashSet<ProductPerOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int? StockQty { get; set; }
        public double? Weight { get; set; }

        public virtual ICollection<CategoryPerProduct> CategoryPerProduct { get; set; }
        public virtual ICollection<ProductPerOrder> ProductPerOrder { get; set; }
    }
}
