using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonor_01.Models
{
    public class DonorViewModel
    {
        public int Id { get; set; }    
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }    
        public string Gender { get; set; }
        public int Age { get; set; }
        public int BloodGroupId { get; set; } 
        public string BloodGroup { get; set; }
        public string Phone { get; set; }  
        public string Adress { get; set; }
        public int AreaId { get; set; }
        public string Area { get; set; }
        public string Password { get; set; }
        public int NumberOfDonation { get; set; }       
        public string LastDonationDate { get; set; }

        public DonorViewModel()
        {

        }

    }
    
}