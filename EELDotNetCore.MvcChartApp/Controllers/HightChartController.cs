using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcChartApp.Controllers
{
	public class HightChartController : Controller
	{
		public IActionResult PieChart()
		{
			return View();
		}

		public IActionResult AreaHighChart()
		{
			return View();
		}
		public IActionResult StackedAndGroupedChart()
		{
			return View();
		}
	}
}
