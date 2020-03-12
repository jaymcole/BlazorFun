using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseWelcomePage();

            // Allows access to all files in wwwroot
            ////app.UseStaticFiles();

            //// Restricts some access to wwwroot
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider($@"{env.WebRootPath}\Images"),
            //    RequestPath = new PathString("/img")
            //});


            //// Only the first delegate is used :O
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World doop doop! ");
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("2nd middleware in the pipeline!");
            //});

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World, from Production! <br/>");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("2nd middleware in the pipeline!");

            });
        }

        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseWelcomePage();
            app.UseWelcomePage();
        }


    }
}
