using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace CacheMemoryWithMiddleware
{
    public class CachedDataMiddleware
    {
        RequestDelegate _next;
        IMemoryCache _cache;

        public CachedDataMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            _cache.Set<String>("NameFromCachedDataMiddleware", "StefFromCachedDataMiddleware");
            await context.Response.WriteAsync("From CachedDataMiddleware : I store data in cache via IMemoryCache from a middleware \n");        
            await _next.Invoke(context);
        }
    }
}
