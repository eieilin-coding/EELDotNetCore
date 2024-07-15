using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcChartApp.Controllers
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
