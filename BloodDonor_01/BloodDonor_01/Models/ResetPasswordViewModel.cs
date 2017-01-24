using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonor_01.Models
{
    public class ResetPasswordViewModel
    {
        [RegularExpression(@"^\(?([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (017XXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [Required]
        [DisplayName("Contact No.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please choose an username")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Pick a username of at least 3 letters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}