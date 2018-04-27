using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Phone is Required")]
        [StringLength(20, ErrorMessage = "Exceeded the length for phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for first name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "E-mail is Required")]
        [StringLength(50, ErrorMessage = "Exceeded the length for e-mail")]
        public string Email { get; set; }

        public string ImageBase64 { get; set; }

    }
}
