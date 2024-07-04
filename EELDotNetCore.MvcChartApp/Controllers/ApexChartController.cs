using EELDotNetCore.MvcChartApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PatternedDonutPieChart()
        {
            PatternedDonutPieChartModel model = new PatternedDonutPieChartModel();
            model.Labels = new List<string>() { "Comedy", "Action", "SciFi", "Drama", "Horror" };
            model.Series = new List<int> { 44, 55, 41, 17, 15 };
            return View(model);
        }
    }
}
