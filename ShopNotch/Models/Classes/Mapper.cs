using Data.Models;

namespace ShopNotch.Models.Classes
{
	public class Mapper
	{
		public CategoryModel GetCategoryModel(Category category)
		{
			var model = new CategoryModel
			{
				Id = category.Id,
				Name = category.Name,
				ParentId = category.ParentId
			};

			if (category.Parent != null)
			{
				model.Parent = GetCategoryModel(category.Parent);
			}

			return model;
		}

		public Category GetCategoryFromModel(CategoryModel model)
		{
			var category = new Category
			{
				Id = model.Id,
				Name = model.Name,
				ParentId = model.ParentId
			};

			if (category.Parent != null)
			{
				category.Parent = GetCategoryFromModel(model.Parent);
			}

			return category;
		}

		public ProductModel GetProductModel(Product product)
		{
			var model = new ProductModel
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Sku = product.Sku,
				Length = product.Length,
				Width = product.Width,
				Height = product.Height,
				StockQty = product.StockQty,
				Weight = product.Weight
			};

			return model;
		}

		public Product GetProductFromModel(ProductModel model)
		{
			var product = new Product
			{
				Id = model.Id,
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				Sku = model.Sku,
				Length = model.Length,
				Width = model.Width,
				Height = model.Height,
				StockQty = model.StockQty,
				Weight = model.Weight
			};

			return product;
		}

	}
}
