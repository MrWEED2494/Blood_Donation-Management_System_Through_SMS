using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonor_01.Models
{
    public class NeedBloodModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter patient Name")]
        [DisplayName("Patient Name")] 
        public string Name { get; set; }
        [DisplayName("Blood Group")]
        [Required(ErrorMessage = "select blood group")]
        public int BloodGroup { get; set; }
        [Required(ErrorMessage = "Select an Area")]
        [DisplayName("Hospital's Area(District)")]
        public int Area { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("Hospital's Address")]
        public string Adrees { get; set; }

        [Required(ErrorMessage = "Age is required")]        
        public int Age { get; set; }
        [Required(ErrorMessage = "select a gender")]
        public int Gender { get; set; }
        [RegularExpression(@"^\(?([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (017XXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [Required]
        [DisplayName("Contact No.")]
        public string Phone { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DisplayName("Short Name of Disease")]
        public string Disease { get; set; }

    }
}