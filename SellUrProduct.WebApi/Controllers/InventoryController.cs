using Microsoft.AspNetCore.Mvc;

namespace SellUrProduct.WebApi.Controllers
{
	public class InventoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
