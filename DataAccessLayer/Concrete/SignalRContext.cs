using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
	public class SignalRContext : DbContext

	{
		//override onConfiguring yazmak yeterli snippet olarak
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-N9UK4PN;Initial Catalog=SignalRDb;Integrated Security=True;TrustServerCertificate=True;");

		}

		public DbSet<About> Abouts { get; set; }

		public DbSet<Booking> Bookings { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Discount> Discounts { get; set; }

		public DbSet<Feature> Features { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<SocialMedia> SocialMedias { get; set; }

		public DbSet<Testimonial> Testimonials { get; set; }

		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

	}
}
