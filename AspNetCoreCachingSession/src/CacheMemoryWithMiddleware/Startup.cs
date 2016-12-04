﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace CacheMemoryWithMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IMemoryCache cache)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCachedDataMiddleware();
            app.UseCachedDataMiddlewareAdvanced();
            app.UseCachedDataMiddlewareWithCallback();
            app.Use(async (context, next) =>
            {
                var nameFromCachedDataMiddleware = cache.Get<String>("NameFromCachedDataMiddleware");
                var nameFromCachedDataMiddlewareAdvanced = cache.Get<String>("NameFromCachedDataMiddlewareAdvanced");
                var userDataFromCachedDataMiddlewareWithCallback = cache.Get<UserData>("UserDataFromCachedDataMiddlewareWithCallback");
                await context.Response.WriteAsync($"NameFromCachedDataMiddleware: {nameFromCachedDataMiddleware} \nNameFromCachedDataMiddlewareAdvanced: {nameFromCachedDataMiddlewareAdvanced} \nUserDataFromCachedDataMiddlewareWithCallback: {userDataFromCachedDataMiddlewareWithCallback.Name} \n");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello From Run!");
            });
        }
    }
}
