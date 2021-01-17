using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UdemyNLayerProject.API.Extensions;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repositories;
using UdemyNLayerProject.Data.UnitOfWorks;
using UdemyNLayerProject.Service.Services;

namespace UdemyNLayerProject.API
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
        {//bu startup.cs dosyasýnýn güncellemesi sadece bunu ekledik.addscoped olanlar
            //consulactor da karþýlaþtýðý zaman hangisinden nesne örneði oluþturacaðýný
            //biiyorum
            services.AddAutoMapper(typeof(Startup));
            //notfountfilter burda kaydedelim
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            //birde ben unitof kullanýcaðýmdan dolayý bunuda ekleyelim
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            //appseting.json tanýmlanýðýmýz kýsmý buraya connectionstring i yapýþtýrýyoruz.

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                 {
                     o.MigrationsAssembly("UdemyNLayerProject.Data");
                 });
            });

            //birde ben unitof kullanýcaðýmdan dolayý bunuda ekleyelim
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers(o =>
                {
                    o.Filters.Add(new ValidationFilter());


                });

            //iþte burda toplu hata mesajýný burda vericez 
            //validationFilter
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                //burda hatayý ben vericem diyoruz.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //buraya tanýttýk hatayý action metodunu
            app.UseCustomException();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
