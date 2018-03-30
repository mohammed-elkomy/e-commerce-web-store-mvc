using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int ReviewerId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(0,5)]
        public int Rating { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("ReviewerId")]
        public User User { get; set; }
    }
}
