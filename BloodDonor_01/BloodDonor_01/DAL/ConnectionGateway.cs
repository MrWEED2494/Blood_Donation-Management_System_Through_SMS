using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonor_01.DAL
{
    public class ConnectionGateway
    {
        public string GetConnection()
        {
            string connectionString = @"Server=(localdb)\v11.0; Database = MyProject; Integrated Security=true";
            return connectionString;
        }
    }
}