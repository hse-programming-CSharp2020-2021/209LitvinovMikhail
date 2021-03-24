using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;



namespace Classwork1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/home", home =>
            {
                home.Map("/myprogram", MyProgram);
                home.Map("/about", About);
                home.Map("/calc", Calculate);
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found");
            });
        }


        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Mikhail");
            });
        }

        private static void Calculate(IApplicationBuilder app) {
            app.UseMiddleware<TokenMiddleware>();
        }

        private static void MyProgram(IApplicationBuilder app) {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(File.ReadAllText(@".\Program.cs"));

            });
        }
    }
}