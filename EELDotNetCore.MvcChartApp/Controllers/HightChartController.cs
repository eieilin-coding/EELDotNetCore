using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.MvcChartApp.Controllers
{
	public class HightChartController : Controller
	{
		public IActionResult PieChart()
		{
			return View();
		}
	}
}
