using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("tags")]
    public class Tags
    {
        public Tags()
        {
            ItemTag = new HashSet<ItemTag>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }

        [InverseProperty("Tag")]
        public ICollection<ItemTag> ItemTag { get; set; }
    }
}
