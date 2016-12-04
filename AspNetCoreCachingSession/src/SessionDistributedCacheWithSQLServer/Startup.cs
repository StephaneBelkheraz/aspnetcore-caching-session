using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SessionDistributedCacheWithSQLServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // To generate a SQL Server table to store session we have execute the following command-line:
            // dotnet sql-cache create "Data Source=MCNLTP173;Initial Catalog=MvcSessions;Integrated Security=True" dbo TestSession

            // Now I have to configure the DistributedSqlServerCache options with the previous connectionString i used to create my table 
            // Of course, my connectionString should come from an appsettings.json file and protected by the user-secrets feature
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = @"Data Source=MCNLTP173;Initial Catalog=MvcSessions;Integrated Security=True";
                options.SchemaName = "dbo";
                options.TableName = "TestSession";
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

            app.Run(async (context) =>
            {
                var name = context.Session.GetString("Name");
                await context.Response.WriteAsync("Hello " + name);
            });
        }
    }
}
