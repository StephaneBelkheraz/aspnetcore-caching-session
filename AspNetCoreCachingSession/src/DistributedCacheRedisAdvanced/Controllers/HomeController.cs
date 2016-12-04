using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DistributedCacheRedisAdvanced.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheRedis _cache;
        public HomeController(ICacheRedis cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            List<string> listColors = new List<string>
            {
                    "green", "white", "black"
            };

            _cache.Set<List<string>>("listColors", listColors);

            return View();
        }

        public IActionResult ShowCacheData()
        {
            List<string> listColors = _cache.Get<List<string>>("listColors");

            return View(listColors);
        }

    }
}
