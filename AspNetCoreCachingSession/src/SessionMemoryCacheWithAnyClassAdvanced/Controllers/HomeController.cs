using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SessionMemoryCacheWithAnyClassAdvanced.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository _productRepository;
        public HomeController(IDataRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var productsFromRepo = _productRepository.GetAll();
            return View(productsFromRepo);
        }
    }
}
