using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcApp2.Controllers
{
    public class HightChartController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
    }
}
