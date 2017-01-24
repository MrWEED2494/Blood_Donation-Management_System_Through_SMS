using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodDonor_01.Models
{
    public class NeedBloodViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }     
        public int BloodGroupId { get; set; }
        public string BloodGroup { get; set; }

        public string Address { get; set; }
        public int AreaId { get; set; }

        public string Area { get; set; }

        public int Age { get; set; }       
        public string Gender { get; set; }        
        public string Phone { get; set; }       
        public string Disease { get; set; }

        public string RequestDate { get; set; }

        public NeedBloodViewModel()
        {
            
        }
    }
}