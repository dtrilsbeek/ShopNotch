using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
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

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
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
				options.IdleTimeout = TimeSpan.FromSeconds(10);
				options.Cookie.HttpOnly = true;
				// Make the session cookie essential
				options.Cookie.IsEssential = true;
			});

			//			services.AddScoped<ILogic, ProductLogic>();
			services.AddSingleton<ILogic<Product>>( new ProductLogic());
			services.AddSingleton<ILogic<Category>>( new CategoryLogic());

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

//			var connection = @"Data Source=(localdb)\mssqllocaldb;AttachDbFilename=C:\Users\dtril\Documents\ShopNotch\TestDB.mdf;Initial Catalog=TestDb;Integrated Security=True";
			//var connection = @"Data Source=mssql.fhict.local;Initial Catalog=dbi391176_elayed;Integrated Security=False;Persist Security Info=False;User ID=dbi391176_elayed;Password=testappels123;";
			//services.AddDbContext<ShopNotchDbContext>(options => options.UseSqlServer(connection));
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
