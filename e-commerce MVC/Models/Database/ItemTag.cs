using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("itemTag")]
    public class ItemTag
    {
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("tag_id")]
        public int TagId { get; set; }
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ItemTag")]
        public Products Product { get; set; }
        [ForeignKey("TagId")]
        [InverseProperty("ItemTag")]
        public Tags Tag { get; set; }
    }
}
