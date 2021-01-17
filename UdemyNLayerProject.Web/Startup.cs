using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repositories;
using UdemyNLayerProject.Data.UnitOfWorks;
using UdemyNLayerProject.Service.Services;
//using UdemyNLayerProject.Core.Repositories;
//using UdemyNLayerProject.Core.Services;
//using UdemyNLayerProject.Core.UnitOfWork;
//using UdemyNLayerProject.Data;
//using UdemyNLayerProject.Data.Repositories;
//using UdemyNLayerProject.Data.UnitOfWorks;
//using UdemyNLayerProject.Service.Services;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web
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
            services.AddHttpClient<CategoryApiService>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration["baseUrl"]);

            });
            //services.AddHttpClient<CategoryApiService>(opt =>

            //{


            //    opt.BaseAddress = new Uri(Configuration["baseUrl"]);

            //}).ConfigurePrimaryHttpMessageHandler(() =>

            //{

            //    var handler = new HttpClientHandler();

            //    handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            //    handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;

            //    return handler;

            //});

           

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IProductService, ProductService>();
            ////birde ben unitof kullanýcaðýmdan dolayý bunuda ekleyelim
            //services.AddScoped<IUnitOfWork, UnitOfWork>();



            ////appseting.json tanýmlanýðýmýz kýsmý buraya connectionstring i yapýþtýrýyoruz.

            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
            //    {
            //        o.MigrationsAssembly("UdemyNLayerProject.Data");
            //    });
            //});




            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
