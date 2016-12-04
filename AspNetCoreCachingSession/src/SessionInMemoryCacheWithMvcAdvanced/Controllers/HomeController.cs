using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SessionInMemoryCacheWithMvcAdvanced.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var userDataFromMiddleware = HttpContext.Session.Get<UserData>("data");
            ViewBag.SessionFromMiddleware = $"I retrieve a clr object from a middleware to mvc controller, the userData Name is : {userDataFromMiddleware.Name}";
            var jsonStringFromStartup = HttpContext.Session.GetObjectFromJson<UserData>("StefJsonFromStartup");
            ViewBag.SessionFromStartup += $"I retrieve a json object from startup to mvc controller, the json userData Name is : {jsonStringFromStartup.Name}";

            return View();
        }
    }
}
