using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopNotch.Models
{
	public class ProductViewModel
	{
		public Product Product { get; set; }
		public CategoryViewModel CategoryModel { get; set; }

		public ProductViewModel()
		{
			
		}
	}
}
