using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonor_01.Models
{
    public class Donor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please choose an username")] 
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Pick a username of at least 3 letters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "first name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
         [DisplayName("Middle Name")]
         [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "last name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "select a gender")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(17,70, ErrorMessage = "Age must be in between 17 to 70")]
        public int Age { get; set; }
        [DisplayName("Blood Group")]
        [Required(ErrorMessage = "select blood group")]
        public int BloodGroup { get; set; }
        [RegularExpression(@"^\(?([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (01XXXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [Required]
        [DisplayName("Contact No.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Select an Area")]
        [DisplayName("Area(District you live in)")]
        public int Area { get; set; }

        [DisplayName("Choose Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Enter '0' if you don't donate yet")]
        [DisplayName("How Many Times you Donated")]
        public int NumberOfDonation { get; set; }
        [DisplayName("Date of Your Last Donation")]
        [RegularExpression("^((0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])[- /.](19|20)?[0-9]{2})*$", ErrorMessage = "Enter date in format MM/DD/YYYY")]
        public string LastDonationDate { get; set; }
        public virtual string BLoodGroupName { get; set; }
        public Donor(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Donor()
        {
            
        }
    }
}