using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Sasi", DisplayOrder = 1 },
				new Category { Id = 3, Name = "abi", DisplayOrder = 5 },
				new Category { Id = 5, Name = "Sasi", DisplayOrder = 6 },
				new Category { Id = 7, Name = "Sasi", DisplayOrder = 8 },
				new Category { Id = 2, Name = "Sasi", DisplayOrder = 1 });
		}
	}
}
