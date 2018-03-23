using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("categories")]
    public class Categories
    {
        public Categories()
        {
            InverseParent = new HashSet<Categories>();
            Products = new HashSet<Products>();
        }

        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public Categories Parent { get; set; }
        [InverseProperty("Parent")]
        public ICollection<Categories> InverseParent { get; set; }
        [InverseProperty("CategoryNavigation")]
        public ICollection<Products> Products { get; set; }
    }
}
