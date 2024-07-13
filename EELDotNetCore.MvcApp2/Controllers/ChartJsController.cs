using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcApp2.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }

        public IActionResult InterpolationLineChart()
        {
            return View();
        }
    }
}
