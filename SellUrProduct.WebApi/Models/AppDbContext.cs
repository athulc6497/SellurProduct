using Microsoft.EntityFrameworkCore;
using SellurProduct.Model;

namespace SellUrProduct.WebApi.Models
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

		public DbSet<Item> Item { get; set; }
		public DbSet<ProductDescription> ProductDescription { get; set; }
		public DbSet<Review> Review { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Item>()
				.Property(i => i.Price)
				.HasPrecision(18, 3);

			modelBuilder.Entity<Item>()
				.Property(i => i.Quantity)
				.HasPrecision(18, 3);



			modelBuilder.Entity<ProductDescription>()
				.HasOne(pd => pd.Item)
				.WithOne(i => i.ProductDescription)
				.HasForeignKey<ProductDescription>(pd => pd.ItemId);

			modelBuilder.Entity<Review>()
				.HasOne(r => r.Item)
				.WithOne(i => i.Review)
				.HasForeignKey<Review>(r => r.ItemId);



			base.OnModelCreating(modelBuilder);
		}
	}
}
