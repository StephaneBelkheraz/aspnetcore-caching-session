using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewaresAdvanced
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware1
    {
        private readonly RequestDelegate _next;

        public MyMiddleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Hello from first middleware before Request \n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Hello from first middleware after Request \n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    
}
