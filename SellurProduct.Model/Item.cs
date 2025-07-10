namespace SellurProduct.Model
{
	public class Item
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool IsOnStock { get; set; }
		public decimal? Price { get; set; }
		public decimal? Quantity { get; set; }
		public string? ImagePath { get; set; }


		// Navigation property
		public ProductDescription ProductDescription { get; set; }
		public Review Review { get; set; }


	}
}
