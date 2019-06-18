using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IntegrationTests
{
	public class IntegrationTests
		: IClassFixture<WebApplicationFactory<ShopNotch.TestStartup>>
	{
		private readonly WebApplicationFactory<ShopNotch.TestStartup> _factory;

		public IntegrationTests(WebApplicationFactory<ShopNotch.TestStartup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("/")]
		[InlineData("/Shop/Index")]
		[InlineData("/Shop/Categories")]
		[InlineData("/Shop/Cart")]
		[InlineData("/Notch")]
		[InlineData("/Notch/Products")]
		[InlineData("/Notch/Products/Edit/1")]
		[InlineData("/Notch/Products/Details/1")]
		[InlineData("/Notch/Products/Delete/1")]
		[InlineData("/Notch/Categories")]
		[InlineData("/Notch/Categories/Edit/2")]
		[InlineData("/Notch/Categories/Delete/2")]
		public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
		{
			
			// Arrange
			var client = _factory.CreateClient();

			// Act
			var response = await client.GetAsync(url);

			// Assert
			response.EnsureSuccessStatusCode(); // Status Code 200-299
			Assert.Equal("text/html; charset=utf-8",
				response.Content.Headers.ContentType.ToString());
		}


	}
}