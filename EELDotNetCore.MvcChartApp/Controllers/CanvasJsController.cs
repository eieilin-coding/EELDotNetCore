using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcChartApp.Controllers
{
	public class CanvasJsController : Controller
	{
		private readonly ILogger<CanvasJsController> _logger;

		public CanvasJsController(ILogger<CanvasJsController> logger)
		{
			_logger = logger;
		}

		public IActionResult LineChart()
		{
			_logger.LogInformation("Line Chart....");
			return View();
		}

		public IActionResult SplineChart()
		{
			return View();
		}
		public IActionResult CandleStickChart()
		{
			return View();
		}
	}
}
