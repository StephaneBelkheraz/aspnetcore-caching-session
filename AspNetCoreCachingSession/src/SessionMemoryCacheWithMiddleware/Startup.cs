using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SessionMemoryCacheWithMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
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
                context.Session.SetString("NameFromStartup", "Stephane");
                await context.Response.WriteAsync("I store data in Session from Startup \n");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                var nameFromStartup = context.Session.GetString("NameFromStartup");
                var nickNameFromMiddleware = context.Session.GetString("NickNameFromMiddleware");
                await context.Response.WriteAsync($"NameFromStartup: {nameFromStartup}, nickNameFromMiddleware: {nickNameFromMiddleware} \n");
            });
        }
    }
}
