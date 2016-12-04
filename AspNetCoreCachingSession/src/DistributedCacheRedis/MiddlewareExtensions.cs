using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedCacheRedis
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseStoredDataMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DistributedCacheRedisMiddleware>();
        }
    }
}
