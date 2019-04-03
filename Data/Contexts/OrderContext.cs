﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts
{
	public class OrderContext : BaseDb<Order>, IContext
	{
		protected override void Map(IDataRecord record, Order entity)
		{
			entity.Id = (int)record["Name"];
			entity.ShopId = (int)record["ShopId"];
			entity.BillingAddressId = (int)record["BillingAddressId"];
			entity.ShippingAddressId = (int)record["ShippingAddressId"];
			entity.DateCreated = (DateTime)record["DateCreated"];
			entity.Email = (string)record["Email"];
			entity.Status = (int)record["Status"];
			entity.BillingAddress = (Address)record["BillingAddress"];
			entity.ShippingAddress = (Address)record["ShippingAddress"];
			entity.Shop = (Shop)record["Shop"];
			entity.OrderLog = (ICollection<OrderLog>)record["OrderLog"];
			entity.ProductPerOrder = (ICollection<ProductPerOrder>)record["ProductPerOrder"];
		}

		protected override Order CreateEntity()
		{
			return new Order();
		}

		public IEnumerable<IEntity> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}