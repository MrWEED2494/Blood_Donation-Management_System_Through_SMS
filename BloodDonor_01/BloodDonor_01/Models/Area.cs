using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonor_01.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Area(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}