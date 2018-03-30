using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class Advertisement
    {
        public Advertisement()
        {
            Categories = new HashSet<CategoryAdvertisement>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        [StringLength(50)]
        public string Caption { get; set; }
        public long Appears { get; set; }
        public bool Enabled { get; set; }

        public ICollection<CategoryAdvertisement> Categories { get; set; }
    }
}