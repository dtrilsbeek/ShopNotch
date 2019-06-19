using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Data.Contexts;
using Data.Models;
using IntegrationTests.Helpers;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
		public async Task Post_ProductForm_ReturnsSuccess_WhenAllFieldsAreFilled()
		{
			// Arrange
			var client = _factory.CreateClient();
			var defaultPage = await _client.GetAsync("/Notch/Products/Create");
			var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
			var form = (IHtmlFormElement) content.QuerySelector("form[id='save-product']");
			var button = (IHtmlButtonElement) content.QuerySelector("button[id='save-product-button']");

			// Act
			var response = await client.SendAsync(
				form,
				button,
				new Dictionary<string, string>
				{
					["Name"] = "TestProductName",
					["Description"] = "TestProductName",
					["Price"] = "1234",
					["Sku"] = "test-sku",
					["StockQty"] = "1233",
					["Weight"] = "12",
					["Length"] = "22",
					["Width"] = "11",
					["Height"] = "10",
				});

			var responseCode = defaultPage.StatusCode;

			// Assert
			Assert.Equal(HttpStatusCode.OK, responseCode );
			// A ModelState failure returns to Page (200-OK) and doesn't redirect.
			response.EnsureSuccessStatusCode();
			Assert.Null(response.Headers.Location?.OriginalString);
		}
	}
}