using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ResponseCacheAttributes.Controllers
{
    [ResponseCache(Duration = 600)]
    public class HomeController : Controller
    {
        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Index()
        {
            ViewData["ToDay"] = DateTime.Now.ToString();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        // On configurera via Duration, Location et VaryBy*
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 20)]
        public IActionResult Contact()
        {

            return View();
        }

        // Les valeurs possibles pou ResponseCacheLocation sont : Client, Any et None
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Infos()
        {
            return View();
        }

    }


}
