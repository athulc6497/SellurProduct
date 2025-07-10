using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellurProduct.Model
{
	public class Review
	{
		public int Id { get; set; }
		public int Rating { get; set; }
		public string ReviewsBlog { get; set; }
		public int ItemId { get; set; }
		public Item Item { get; set; }
	}
}
