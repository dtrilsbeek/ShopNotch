using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class CategoryLogicTests
	{
		// TODO: Apply naming conventions
		[TestMethod]
		public void TestCategoryTree()
		{
			var logic = new CategoryLogic();

			var tree = logic.GetCategoryTree();

			Assert.IsTrue(tree.Nodes[0].Entity.Name == "Laptops");
			Assert.IsTrue(tree.Nodes[0].SubNodes[0].Entity.Name == "Gaming");
		}
	}
}
