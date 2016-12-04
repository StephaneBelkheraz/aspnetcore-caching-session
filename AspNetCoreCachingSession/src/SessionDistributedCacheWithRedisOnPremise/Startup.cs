using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SessionDistributedCacheWithRedis
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "test";
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".Session";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseStoredDataMiddleware();

            app.Use(async (context, next) =>
            {
                context.Session.SetString("NickName", "Stef");
                await context.Response.WriteAsync("I store data in Session with Distributed Cache Redis OnPremise from startup \n");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                var name = context.Session.GetString("Name");
                var nickName = context.Session.GetString("NickName");
                await context.Response.WriteAsync($"My name is {name} and my nickname is {nickName}");
            });
        }
    }
}
