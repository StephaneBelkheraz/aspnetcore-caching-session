using Microsoft.AspNetCore.Builder;

namespace SessionDistributedCacheWithSQLServer
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
