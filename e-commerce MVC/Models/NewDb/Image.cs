using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        public int ProductId { get; set; }


        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}