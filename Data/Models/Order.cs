using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLog = new HashSet<OrderLog>();
            ProductPerOrder = new HashSet<ProductPerOrder>();
        }

        public int Id { get; set; }
        public int? ShopId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }

        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<OrderLog> OrderLog { get; set; }
        public virtual ICollection<ProductPerOrder> ProductPerOrder { get; set; }
    }
}
