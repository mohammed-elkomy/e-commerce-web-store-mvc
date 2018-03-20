using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.Database
{
    public class UserRole : IdentityRole<int>
    {
        public override int Id { get; set; }
    }
}