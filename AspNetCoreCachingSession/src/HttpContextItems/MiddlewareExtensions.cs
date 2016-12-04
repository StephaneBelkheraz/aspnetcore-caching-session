using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpContextItems
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseStoredDataMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StoredDataMiddleware>();
        }
    }
}
