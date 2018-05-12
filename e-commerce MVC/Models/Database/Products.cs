using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("products")]
    public class Products
    {
        public Products()
        {
            ItemTag = new HashSet<ItemTag>();
            Sales = new HashSet<Sales>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("image1")]
        public string Image1 { get; set; }
        [Column("image2")]
        public string Image2 { get; set; }
        [Column("image3")]
        public string Image3 { get; set; }
        [Column("price")]
        public double Price { get; set; }

        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [StringLength(255)]
        public string ShortDescription { get; set; }

        [Column("category")]
        public int Category { get; set; }
        [Column("sold_count")]
        public int SoldCount { get; set; }
        [Required]
        [Column("on_sale", TypeName = "binary(1)")]
        public bool OnSale { get; set; }
        [Column("sale_info")]
        public double? SaleInfo { get; set; }

        [ForeignKey("Category")]
        [InverseProperty("Products")]
        public Categories CategoryNavigation { get; set; }
        [InverseProperty("Product")]
        public ICollection<ItemTag> ItemTag { get; set; }
        [InverseProperty("Product")]
        public ICollection<Sales> Sales { get; set; }
        [InverseProperty("Product")]
        public ICollection<Review> Reviews { get; set; }

    }
}
