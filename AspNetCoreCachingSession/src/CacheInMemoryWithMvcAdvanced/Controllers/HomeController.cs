using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CacheInMemoryWithMvcAdvanced.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        public HomeController(IMemoryCache cache)
        {
            _cache = cache;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            UserData user = new UserData { Id = 1, Name = "StefFromController" };
            _cache.Set<UserData>("userData", user,
                new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(6)));
            return View();
        }

        public IActionResult About()
        {
            var user = _cache.Get<UserData>("userData");
            return View(user);
        }
    }
}
