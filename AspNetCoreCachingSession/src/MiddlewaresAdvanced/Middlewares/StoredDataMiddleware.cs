using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewaresAdvanced
{
    public class StoredDataMiddleware
    {
        RequestDelegate _next;
        IMemoryCache _cache;
        private readonly IDataRepository _repo;

        public StoredDataMiddleware(RequestDelegate next, IMemoryCache cache, IDataRepository repo)
        {
            _next = next;
            _cache = cache;
            _repo = repo;
        }

        public async Task Invoke(HttpContext context)
        {
            var name = _repo.GetAll().FirstOrDefault().Name;
            _cache.Set<string>("Name", name);
            await context.Response.WriteAsync($"I put in cache datas in a middleware: the first product name is : {name} \n");
            await _next.Invoke(context);
        }
    }
}
