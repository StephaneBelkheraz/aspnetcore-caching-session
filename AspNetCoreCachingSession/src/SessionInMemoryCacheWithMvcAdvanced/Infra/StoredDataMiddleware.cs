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
        UserData data = new UserData
        {
            Id = 054,
            Name = "StefFromMiddlewareOrAnywhereElse"
        };
        context.Session.Set<UserData>("data", data);    
        await _next.Invoke(context);
    }
}

