using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcApp2.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult LineChart()
        {
            return View();
        }
    }
}
