using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShopNotch
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public virtual DbConfig GetDbConfig()
		{
			return new DbConfig(Configuration.GetSection("DbConfig")["ShopNotchContext"]);
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public virtual void ConfigureServices(IServiceCollection services)
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

//			services.AddSingleton<IDbConfig, DbConfig>(opt => new DbConfig(Configuration.GetSection("DbConfig")["ShopNotchTestContext"]));
			services.AddSingleton<IDbConfig, DbConfig>(opt => GetDbConfig());
			services.AddTransient<IProductLogic, ProductLogic>();
			services.AddTransient<ICategoryLogic, CategoryLogic>();
			services.AddTransient<ICartLogic, CartLogic>();
			

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseSession();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "Notch",
					template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
					);

				routes.MapRoute(
					name: "default",
					template: "{controller=Shop}/{action=Index}/{id?}");
			});
		}
	}
}
