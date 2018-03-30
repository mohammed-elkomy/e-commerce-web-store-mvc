using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.NewDb
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            Reviews = new HashSet<Review>();
            Products = new HashSet<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public override string Email { get; set; }
        [Required]
        public bool NewsSubscription { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }


        [InverseProperty("User")]
        public ICollection<Review> Reviews { get; set; }
        [InverseProperty("User")]
        public ICollection<Product> Products { get; set; }
    }
}
