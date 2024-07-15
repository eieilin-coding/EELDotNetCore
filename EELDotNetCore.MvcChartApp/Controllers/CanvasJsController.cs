using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcChartApp.Controllers
{
	public class CanvasJsController : Controller
	{
		public IActionResult LineChart()
		{
			return View();
		}
	}
}
