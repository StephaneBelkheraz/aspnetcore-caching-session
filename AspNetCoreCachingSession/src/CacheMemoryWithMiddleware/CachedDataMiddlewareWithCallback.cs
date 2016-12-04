using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheMemoryWithMiddleware
{
    public class CachedDataMiddlewareWithCallback
    {
        RequestDelegate _next;
        IMemoryCache _cache;

        public CachedDataMiddlewareWithCallback(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            UserData user = new UserData
            {
                Id = 1,
                Name = "StefFromCachedDataMiddlewareWithCallback"
            };

            string logMessage = string.Empty;

            _cache.Set("UserDataFromCachedDataMiddlewareWithCallback", user,
                new MemoryCacheEntryOptions()
                        .RegisterPostEvictionCallback((key, value, reason, substate) =>
                            {
                                logMessage = $"'{key}':'{value}' was evicted because: {reason}";
                                // log message
                            }
            ));

            // reason : Removed, Replaced, Expired, TokenExpired, Capacity

            await context.Response.WriteAsync("From CachedDataMiddlewareWithCallback : I store data in cache via IMemoryCache from a middleware \n");        
            await _next.Invoke(context);
        }
    }
}
