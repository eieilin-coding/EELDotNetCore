using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
