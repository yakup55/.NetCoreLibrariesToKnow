using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling
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

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                

                app.UseDeveloperExceptionPage();
                //hata gösterme ve düzeltme
                //1 yol
                //app.UseStatusCodePages("text/plain","Bir hata var durum kodu:{0}");

                //2 yol


                app.UseStatusCodePages(async context =>
                {
                    context.HttpContext.Response.ContentType = "text/plain";
                    await context.HttpContext.Response.WriteAsync($"Bir hata var Durum kodu:{context.HttpContext.Response.StatusCode}");
                });
                // 3 yol
               // app.UseStatusCodePages();
            }
            else
            {
             
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //hata olunca buraya gidicek
            //app.UseExceptionHandler(context =>
            //{
            //    context.Run(async page =>
            //    {
            //        page.Response.StatusCode = 500;
            //        page.Response.ContentType = "text/html";
            //        await page.Response.WriteAsync($"<html><head></head><h1>hata var:{page.Response.StatusCode}</h1></html>");
            //    });
            //});

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
