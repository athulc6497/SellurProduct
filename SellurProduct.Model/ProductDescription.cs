using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellurProduct.Model
{
	public class ProductDescription
	{
		public int Id { get; set; }
		public int ItemId { get; set; }
		public string Dimension  { get; set; }
		public string ProductCareInstruction  { get; set; }
		public string ReturnPolicy	  { get; set; }

		public Item Item { get; set; }
	}
}
