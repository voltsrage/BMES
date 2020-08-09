using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BMES.Database;
using Microsoft.EntityFrameworkCore;
using BMES.Repository;
using BMES.Repository.Implementations;
using BMES.Services;
using BMES.Services.Implementations;

namespace BMES
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

            services.AddDbContext<BmesDbContext>(optionsAction: options => options.UseSqlServer(Configuration.GetConnectionString("BmesWebApp")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ICatalogService, CatalogService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "catalogue/{category_slug}/{brand_slug}/page{page:int}",
                    defaults: new { controller = "Catalogue", action = "Index" });

                routes.MapRoute(
                    name: null,
                    template: "page{page:int}",
                    defaults: new { controller = "Catalogue", action = "Index", productPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "catalogue/{category_slug}/{brand_slug}",
                    defaults: new {
                        controller = "Catalogue",
                        action = "Index",
                        productPage = 1
                    });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Catalogue}/{action=Index}/{id?}");
            });
        }
    }
}
