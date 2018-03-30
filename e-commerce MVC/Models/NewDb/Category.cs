using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class Category
    {
        public Category()
        {
            Children = new HashSet<Category>();
            Products = new HashSet<Product>();
            Advertisements = new HashSet<CategoryAdvertisement>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public ICollection<CategoryAdvertisement> Advertisements { get; set; }

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }
        [InverseProperty("Parent")]
        public ICollection<Category> Children { get; set; }
        [InverseProperty("Category")]
        public ICollection<Product> Products { get; set; }
    }
}