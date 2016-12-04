using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DistributedCacheTagHelpers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // We can use distributed cache with:
            // 1. SQL Server
            //services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString = @"Data Source=MCNLTP173;Initial Catalog=MvcSessions;Integrated Security=True";
            //    options.SchemaName = "dbo";
            //    options.TableName = "TestSession";
            //});

            // 2. Redis on Premise
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "test";
            });

            // 3. Redis on Azure
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = Configuration.GetConnectionString("RedisConnectionString");
            //    option.InstanceName = "master";
            //});


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
