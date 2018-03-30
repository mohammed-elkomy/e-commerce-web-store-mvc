using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models.NewDb
{
    public class DataContext : IdentityDbContext<User, UserRole, int>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductTag>()
                .HasKey(o => new {o.TagId, o.ProductId});
            builder.Entity<CategoryAdvertisement>()
                .HasKey(o => new {o.CategoryId, o.AdvertisementId});
        }
    }
}
