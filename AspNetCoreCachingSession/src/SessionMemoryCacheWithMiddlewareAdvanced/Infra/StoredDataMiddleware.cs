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
        UserData data = new UserData
        {
            Id = 054,
            Name = "StefFromMiddlewareOrAnywhereElse"
        };
        context.Session.Set<UserData>("data", data);
        await context.Response.WriteAsync("I store clr object from a middleware \n");        
        await _next.Invoke(context);
    }
}

