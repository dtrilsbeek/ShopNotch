using System;
using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Models
{
    public partial class Category : IEntity
    {
        public Category()
        {
            CategoryPerProduct = new HashSet<CategoryPerProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<CategoryPerProduct> CategoryPerProduct { get; set; }
    }
}
