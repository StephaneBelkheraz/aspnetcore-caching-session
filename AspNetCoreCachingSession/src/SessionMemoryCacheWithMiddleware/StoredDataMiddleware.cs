using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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
        context.Session.SetString("NickNameFromMiddleware", "stef");
        await context.Response.WriteAsync("I store data in Session from a middleware \n");        
        await _next.Invoke(context);
    }
}

