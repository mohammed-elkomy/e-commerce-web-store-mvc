using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class Product
    {
        public Product()
        {
            Tags = new HashSet<ProductTag>();
            Images = new HashSet<Image>();
            Reviews = new HashSet<Review>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(255)]
        public string ShortDescription { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Required]
        [Range(Double.Epsilon, Double.MaxValue)]
        public double Price { get; set; }
        [Range(0, int.MaxValue)]
        public int SoldCount { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public ICollection<ProductTag> Tags { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [InverseProperty("Product")]
        public ICollection<Image> Images { get; set; }
        [InverseProperty("Product")]
        public ICollection<Review> Reviews { get; set; }
    }
}