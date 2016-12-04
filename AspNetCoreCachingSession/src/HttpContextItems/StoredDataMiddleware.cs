using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpContextItems
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
            context.Items["NickNameFromMiddleware"] = "stef";
            await context.Response.WriteAsync("I store data in HttpContext.Items from a middleware \n");
            await _next.Invoke(context);
        }
    }
}
