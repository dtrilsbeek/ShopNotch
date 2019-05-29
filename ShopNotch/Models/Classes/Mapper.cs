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
	}
}
