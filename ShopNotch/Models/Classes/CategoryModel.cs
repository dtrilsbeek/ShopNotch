namespace ShopNotch.Models.Classes
{
	public class CategoryModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public CategoryModel Parent { get; set; }
	}
}
