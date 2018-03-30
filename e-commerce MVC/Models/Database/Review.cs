using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int ReviewerId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Products Product { get; set; }
        [ForeignKey("ReviewerId")]
        public Users User { get; set; }
    }
}
