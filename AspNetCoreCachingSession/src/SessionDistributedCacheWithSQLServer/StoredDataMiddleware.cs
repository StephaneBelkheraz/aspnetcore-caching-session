using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SessionDistributedCacheWithSQLServer
{
    public class StoredDataMiddleware
    {
        RequestDelegate _next;

        public StoredDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Session.SetString("Name", "stef");
            await context.Response.WriteAsync("I store data in Session with a Distributed SQL Server Session from a middleware \n");        
            await _next.Invoke(context);
        }
    }
}
