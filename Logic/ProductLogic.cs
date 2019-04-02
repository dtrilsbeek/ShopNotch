using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;

namespace Logic
{
	public class ProductLogic
	{
		Repository<Product> productRepository = new Repository<Product>();

		public IEnumerable<Product> GetAllSalesByMonth()
		{
			// Requirement 1.1
			return productRepository.GetAll();
		}

		/*public IEnumerable<Sale> GetAllSalesByQuarter()
		{
			// Requirement 1.1
			return productRepository.List()
				.GroupBy(s => new DateTime(s.Timestamp.Year, ((s.Timestamp.Month - 1) / 3 + 1), 1), s => s.Amount)
				.Select(g => new Sale($"{g.Key.Year}Q{g.Key.Month}", g.Sum(), g.Key));
		}

		public IEnumerable<Sale> GetAllSalesByYear()
		{
			// Requirement 1.1
			return productRepository.List()
				.GroupBy(s => new DateTime(s.Timestamp.Year, 1, 1), s => s.Amount)
				.Select(g => new Sale(g.Key.Year.ToString(), g.Sum(), g.Key));
		}

		public void AddSale(int cashierId, Sale sale)
		{
			Cashier cashier = cashierRepo.GetCashierByIdentification(cashierId);

			if (cashier == null)
			{
				throw new ArgumentException($"No cashier found with id {cashierId}.");
			}

			if (!(cashier is CashierSupervisor))
			{
				if (sale.Amount <= 0)
				{
					// Beperking 3.1
					throw new ArgumentException($"User is not allowed to refund sales.");
				}
				// Beperking 2.3
				sale.SetTimestampToNow();
			}

			productRepository.AddSale(sale);
		}*/
	}
}