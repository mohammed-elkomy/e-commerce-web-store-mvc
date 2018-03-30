using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.NewDb
{
    public class UserRole : IdentityRole<int>
    {
        public override int Id { get; set; }
    }
}