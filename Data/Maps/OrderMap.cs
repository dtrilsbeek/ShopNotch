using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data.Models;

namespace Data.Maps
{
	class OrderMap
	{
		public void Map(IDataRecord record, Order order)
		{
			order.Id = (int) record["Name"];
			order.ShopId = (int) record["ShopId"];
			order.BillingAddressId = (int) record["BillingAddressId"];
			order.ShippingAddressId = (int) record["ShippingAddressId"];
			order.DateCreated = (DateTime) record["DateCreated"];
			order.Email = (string) record["Email"];
			order.Status = (int) record["Status"];
			order.BillingAddress = (Address) record["BillingAddress"];
			order.ShippingAddress = (Address) record["ShippingAddress"];
			order.Shop = (Shop) record["Shop"];
			order.OrderLog = (ICollection<OrderLog>) record["OrderLog"];
			order.ProductPerOrder = (ICollection<ProductPerOrder>) record["ProductPerOrder"];
		}
	}
}