using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheMemoryWithMiddleware
{
    public class CachedDataMiddlewareAdvanced
    {
        RequestDelegate _next;
        IMemoryCache _cache;

        public CachedDataMiddlewareAdvanced(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            _cache.Set<String>("NameFromCachedDataMiddlewareAdvanced", "StefFromCachedDataMiddlewareAdvanced", 
                new MemoryCacheEntryOptions()
                    .SetPriority(CacheItemPriority.NeverRemove)
                    );

            await context.Response.WriteAsync("From CachedDataMiddlewareAdvanced : I store data in cache via IMemoryCache from a middleware \n");        
            await _next.Invoke(context);
        }
    }
}
