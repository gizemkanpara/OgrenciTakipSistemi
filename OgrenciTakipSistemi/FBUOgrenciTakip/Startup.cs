using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using FBUOgrenciTakip.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBUOgrenciTakip
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
            services.AddDbContext<OgrDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MssqlConnection")));

           
            services.AddTransient<NotRepository, NotRepository>();
            services.AddTransient<IRepository<myConfig>, MyCfgRepository>();
            services.AddTransient<IRepository<Ogretmen>, OgretmenRepository>();
            services.AddTransient<IRepository<Ogrenci>, OgrRepository>();
            // services.AddSingleton<IRepository<myConfig>, CfgRepositoryMock>();
            services.AddScoped<MyAuthorizeAttribute>();
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { error = exception.Message };
                Console.WriteLine("exception:" + exception.Message);

              var opt= new DbContextOptionsBuilder<OgrDbContext>().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OgrenciTakipDb;Trusted_Connection=True;MultipleActiveResultSets=true");

                OgrDbContext ctx = new OgrDbContext(opt.Options);
                ctx.Hatalar.Add(new Hata()
                {
                    Error = exception.ToString(),
                    Message = exception.Message,
                    RequestUri = context.Request.Query.ToString(),
                    Tarih = DateTime.Now
                }
                       );
                ctx.SaveChanges();
                

                // await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ogrenci}/{action=Index}/{id?}/{ogrId?}");
            });
        }
    }
}
