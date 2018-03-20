using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models.Database
{
    public partial class ShopDbContext : IdentityDbContext<Users,IdentityRole<int>,int>
    {
        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ItemTag> ItemTag { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ads>(entity =>
            {
                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_categories_categories");
            });

            modelBuilder.Entity<ItemTag>(entity =>
            {
                entity.HasIndex(e => new { e.ProductId, e.TagId })
                    .HasName("UNIQUE_IDS")
                    .IsUnique();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ItemTag)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_itemTag_products");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ItemTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_itemTag_tags");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.SenderEmail).IsUnicode(false);

                entity.Property(e => e.SenderName).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Images).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_products_categories");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_users");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
