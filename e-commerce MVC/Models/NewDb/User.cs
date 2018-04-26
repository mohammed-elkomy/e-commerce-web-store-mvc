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

        public string Firstname { get; set; }


        public string Lastname { get; set; }

        public override string Email { get; set; }

        public bool NewsSubscription { get; set; }


        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Zip Code is Required")]
        [StringLength(10, ErrorMessage = "Exceeded the length for zipcode")]
        public string Zipcode { get; set; }


        [InverseProperty("User")]
        public ICollection<Review> Reviews { get; set; }
        [InverseProperty("User")]
        public ICollection<Product> Products { get; set; }
    }
}
