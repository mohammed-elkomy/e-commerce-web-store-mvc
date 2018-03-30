using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class CategoryAdvertisement
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AdvertisementId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("AdvertisementId")]
        public Advertisement Advertisement { get; set; }
    }
}