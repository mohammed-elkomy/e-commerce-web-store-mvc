using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.Database
{
    public class Users : IdentityUser<int>
    {
        public Users()
        {
            Sales = new HashSet<Sales>();
        }

        
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
        public string Visacard { get; set; }

        [InverseProperty("User")]
        public ICollection<Sales> Sales { get; set; }
    }
}
