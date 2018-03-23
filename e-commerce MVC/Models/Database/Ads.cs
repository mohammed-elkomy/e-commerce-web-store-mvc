using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("ads")]
    public class Ads
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("image")]
        [StringLength(50)]
        public string Image { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("appeared_count")]
        public int? AppearedCount { get; set; }
        [Required]
        [Column("enabled")]
        [MaxLength(1)]
        public byte[] Enabled { get; set; }
    }
}
