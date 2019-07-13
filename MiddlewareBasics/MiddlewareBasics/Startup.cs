using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MiddlewareBasics
{
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2
    //http://learninginurdu.pk/2019/07/10/all-in-one-post/
    //https://github.com/bilalshahzad139/Learning_DotNetCore

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => builder
                                .AddConsole()
                                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Starting....");

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("Start In Use middleware");
            //    await next();
            //    logger.LogInformation("End In Use middleware");
            //});

            //app.UseMiddleware<LearningInUrduMiddleware>();

            app.UseLearningInUrdu();

            app.Map("/employees", a => a.Run(async context =>
            {
                await context.Response.WriteAsync("List of employees");
            }));

            //for /testing (writting anonymous functions)
            app.MapWhen(context => context.Request.Path.Value == "/testing",
                        a => a.Run(async context =>
                        {
                            await context.Response.WriteAsync("Learing In Urdu! for testing123!");
                        }
                    ));

            //for /testing2 (writting named functions instead of anonymous functions)
            app.MapWhen(checkRequest, provideResponse);

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Learing In Urdu!");
            });
        }

        private void provideResponse(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Learing In Urdu! for testing2!");
            });
        }

        private bool checkRequest(HttpContext arg)
        {
            if (arg.Request.Path.Value == "/testing2")
                return true;
            else
                return false;
        }
    }
}
