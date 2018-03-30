using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class ProductTag
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}