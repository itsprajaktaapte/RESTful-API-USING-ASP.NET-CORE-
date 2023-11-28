using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Purchase()
        {
            return View();
        }
    }
}
