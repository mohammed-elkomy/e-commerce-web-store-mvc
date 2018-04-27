using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.ViewModels
{
    public class RegisterViewModel
    {
        //public string Id { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "E-mail is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        [StringLength(20, ErrorMessage = "Exceeded the length for phone")]
        public string PhoneNumber { get; set; }

        public bool SubscripedToNews { get; set; }
        public bool ToSAgreed { get; set; }
    }
}
