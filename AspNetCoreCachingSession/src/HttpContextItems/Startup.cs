using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HttpContextItems
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

            app.UseStoredDataMiddleware();

            app.Use(async (context, next) =>
            {
                context.Items["NameFromStartup"] = "Stephane";
                await context.Response.WriteAsync("I store data in HttpContext.Items from Startup \n\n");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                var nameFromStartup = context.Items["NameFromStartup"];
                var nickNameFromMiddleware = context.Items["NickNameFromMiddleware"];
                await context.Response.WriteAsync($"NameFromStartup: {nameFromStartup}, nickNameFromMiddleware: {nickNameFromMiddleware} \n");
            });

            
        }
    }
}
