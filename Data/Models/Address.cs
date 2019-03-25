using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Address
    {
        public Address()
        {
            OrderBillingAddress = new HashSet<Order>();
            OrderShippingAddress = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? Type { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string StateCounty { get; set; }
        public string Phone { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> OrderBillingAddress { get; set; }
        public virtual ICollection<Order> OrderShippingAddress { get; set; }
    }
}
