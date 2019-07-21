using Data.Contexts;
using Data.Interfaces;
using Logic;
using Logic.Helpers;
using Logic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShopNotch
{
	public class TestStartup : Startup
	{
		public TestStartup(IConfiguration env) : base(env)
		{
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;

			});

			services.AddDistributedMemoryCache();

			services.AddSession(options =>
			{
				// Set a short timeout for easy testing.
				// options.IdleTimeout = TimeSpan.FromSeconds(100);
				options.Cookie.HttpOnly = true;
				// Make the session cookie essential
				options.Cookie.IsEssential = true;
			});

			services.AddSingleton<IDbConfig, DbConfig>(opt => new DbConfig(Configuration.GetSection("DbConfig")["ShopNotchTestContext"]));
			services.AddTransient<IProductLogic, ProductLogic>();
			services.AddTransient<ICategoryLogic, CategoryLogic>();
			services.AddTransient<ICartLogic, CartLogic>();


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			//mock DbContext and any other dependencies here
		}
	}
}