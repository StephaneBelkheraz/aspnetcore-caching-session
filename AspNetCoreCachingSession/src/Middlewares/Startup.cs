using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Middlewares
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("middleware1 Request 1 / ");
                await next.Invoke();
                await context.Response.WriteAsync("middleware1 Response 2 / ");
            });

            app.Map("/mysegment", (appBuilder) =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("middlewareMap Request 2 / ");
                    await next.Invoke();
                    await context.Response.WriteAsync("middlewareMap Response 1/ ");
                });
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("middlewareMap Request 3 / ");
                });
            });

            app.MapWhen(context => context.Request.Query.ContainsKey("qs1"), (appBuilder) =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("MiddlewareMapWhen Request 2 / ");
                    await next.Invoke();
                    await context.Response.WriteAsync("MiddlewareMapWhen Response 1/ ");
                });
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("MiddlewareMapWhen remplit la condition du prédicat Request 3 / ");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("middlewareRun Request 2 / ");
            });

        }
    }
}
