using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheMemoryWithMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCachedDataMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CachedDataMiddleware>();
        }

        public static IApplicationBuilder UseCachedDataMiddlewareAdvanced(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CachedDataMiddlewareAdvanced>();
        }

        public static IApplicationBuilder UseCachedDataMiddlewareWithCallback(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CachedDataMiddlewareWithCallback>();
        }
    }
}
