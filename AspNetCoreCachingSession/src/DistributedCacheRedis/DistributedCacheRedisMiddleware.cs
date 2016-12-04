using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedCacheRedis
{
    public class DistributedCacheRedisMiddleware
    {
        RequestDelegate _next;
        IDistributedCache _cache;

        public DistributedCacheRedisMiddleware(RequestDelegate next, IDistributedCache cacheRedis)
        {
            _next = next;
            _cache = cacheRedis;
        }

        public async Task Invoke(HttpContext context)
        {
            string name = "stef";
            _cache.Set("name", Encoding.UTF8.GetBytes(name));
            await context.Response.WriteAsync("From DistributedCacheRedisMiddleware : I store data in cache via IDistributedCache from a middleware \n");        
            await _next.Invoke(context);
        }
    }
}
