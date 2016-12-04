using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


public class StoredDataMiddleware
{
    RequestDelegate _next;

    public StoredDataMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Session.SetString("Name", "Stephane");
        await context.Response.WriteAsync("I store data in Session with Distributed Cache Redis On Azure from a middleware \n");        
        await _next.Invoke(context);
    }
}

