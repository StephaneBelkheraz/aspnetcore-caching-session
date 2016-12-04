using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewaresAdvanced
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware1>();
        }

        public static IApplicationBuilder UseMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware2>();
        }

        public static IApplicationBuilder UseStoredDataMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StoredDataMiddleware>();
        }

        // StoredDataMiddleware
    }
}
