using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SellurProduct.Model;
using SellUrProduct.UI.Models;

namespace SellUrProduct.UI.Controllers
{
	public class InventoryController : Controller
	{
		private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InventoryController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
            _webHostEnvironment= webHostEnvironment;

        }
       

        public ActionResult AddProduct()
		{
			Item item = new Item();
			return View(item);
		}

		[HttpPost]

		public async Task<IActionResult> AddProduct(Item item,IFormFile image)
		{
			if (image != null && image.Length > 0)
			{
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "ItemImage");

				if (!Directory.Exists(uploadPath))
					Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                item.ImagePath = "/ItemImage/" + fileName;

            }


            await _context.Item.AddAsync(item);
			await _context.SaveChangesAsync();
			return RedirectToAction("Product");
		}

		public IActionResult Product()
		{
            var itemList = _context.Item
                .Select(item => new Item
                {
                    Id = item.Id,
                    Name = item.Name??"",
                    Quantity=item.Quantity??0,
                    Price=item.Price??0,
                    ImagePath = item.ImagePath ?? "default.png"
                })
                .ToList();
            return View(itemList);
		}
	}
}
