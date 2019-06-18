using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Sdk;

namespace IntegrationTests
{
	public class IntegrationTests
		: IClassFixture<WebApplicationFactory<ShopNotch.TestStartup>>
	{
		private readonly WebApplicationFactory<ShopNotch.TestStartup> _factory;
		private HttpClient _client;

		public IntegrationTests(WebApplicationFactory<ShopNotch.TestStartup> factory)
		{
			_factory = factory;
			_client = _factory.CreateClient();
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

		[Fact]
		public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
		{
			// Arrange
			var defaultPage = await _client.GetAsync("/");
			var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

			//Act
			var response = await _client.SendAsync(
				(IHtmlFormElement)content.QuerySelector("form[id='messages']"),
				(IHtmlButtonElement)content.QuerySelector("button[id='deleteAllBtn']"));

			// Assert
			Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
			Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
			Assert.Equal("/", response.Headers.Location.OriginalString);
		}
	}
}