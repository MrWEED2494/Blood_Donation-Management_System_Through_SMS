using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BloodDonor_01.Models;

namespace BloodDonor_01.DAL
{
    public class DonorGateway
    {
        static ConnectionGateway connection=new ConnectionGateway();
        string connectionString = connection.GetConnection();

        public int Insert(Donor donor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Donor (Username, FirstName, MiddleName, LastName, " +
                           "GenderId, Age, BloodGroupId, Phone, Address, AreaId, Pass, NoOfDonation, LastDonationDate) " +
                           "VALUES (@username, @fname, @mname, @lname, @gender, @age, " +
                           "@bloodgroup, @phone, @address, @area, @password, @noOfDonation, @lastDonationDate)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("username", SqlDbType.VarChar);
            command.Parameters["username"].Value = donor.Username;

            command.Parameters.Add("fname", SqlDbType.VarChar);
            command.Parameters["fname"].Value = donor.FirstName;

            command.Parameters.Add("mname", SqlDbType.VarChar);
            command.Parameters["mname"].Value = donor.MiddleName;

            command.Parameters.Add("lname", SqlDbType.VarChar);
            command.Parameters["lname"].Value = donor.LastName;

            command.Parameters.Add("gender", SqlDbType.Int);
            command.Parameters["gender"].Value = donor.Gender;

            command.Parameters.Add("age", SqlDbType.Int);
            command.Parameters["age"].Value = donor.Age;

            command.Parameters.Add("bloodgroup", SqlDbType.Int);
            command.Parameters["bloodgroup"].Value = donor.BloodGroup;

            command.Parameters.Add("phone", SqlDbType.VarChar);
            command.Parameters["phone"].Value = donor.Phone;

            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = donor.Adress;

            command.Parameters.Add("area", SqlDbType.Int);
            command.Parameters["area"].Value = donor.Area;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = donor.Password;

            command.Parameters.Add("noOfDonation", SqlDbType.Int);
            command.Parameters["noOfDonation"].Value = donor.NumberOfDonation;

            command.Parameters.Add("lastDonationDate", SqlDbType.VarChar);
            command.Parameters["lastDonationDate"].Value = donor.LastDonationDate;


            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
            
        }
        public bool IsUsernameUnique(Donor donor)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "select * from Donor where Username=@username";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("username", SqlDbType.VarChar);
            command.Parameters["username"].Value = donor.Username;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsPhoneUnique(Donor donor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Donor where Phone=@phone";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("phone", SqlDbType.VarChar);
            command.Parameters["phone"].Value = donor.Phone;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<BloodGroup> GetAllBloodGroups()
        {
            SqlConnection connection=new SqlConnection(connectionString);

            string query = "select * from BloodGroup";

            connection.Open();
            SqlCommand command=new SqlCommand(query,connection);
            SqlDataReader reader = command.ExecuteReader();

            List<BloodGroup> bloodGroupsList=new List<BloodGroup>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["BloodGroup"].ToString();

                BloodGroup bloodGroup=new BloodGroup(id, name);
                bloodGroupsList.Add(bloodGroup);
            }
            return bloodGroupsList;
        }

        public List<Gender> GetAllGenders()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from DonorGender";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Gender> gendersList = new List<Gender>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Gender"].ToString();

                Gender gender = new Gender(id, name);
                gendersList.Add(gender);
            }
            return gendersList;
        }

        public List<Area> GetAllAreas()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Area";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Area> areaList = new List<Area>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Area"].ToString();

                Area area=new Area(id, name);
                areaList.Add(area);
            }
            return areaList;
        }

        public List<DonorViewModel> GetAllDonors()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select Donor.id as Id, Donor.UserName as Username, Donor.Pass as Password, Donor.FirstName as " +
                "FirstName,Donor.MiddleName as MiddleName, Donor.LastName as LastName, Donor.Phone as Phone, Donor.Age as Age, Donor.NoOfDonation as " +
                "NoOfDonation, Donor.LastDonationDate as LastDonationDate,BloodGroup.Id as BloodGroupId, BloodGroup.BloodGroup as BloodGroup, Area.Id as AreaID, Area.Area as Area " +
                "from Donor left outer join BloodGroup on Donor.BloodGroupId=BloodGroup.Id left outer join Area on " +
                "Donor.AreaId=Area.Id";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<DonorViewModel> donorsList = new List<DonorViewModel>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string username = reader["UserName"].ToString();
                string password = reader["Password"].ToString();
                string fname = reader["FirstName"].ToString();
                string mname = reader["MiddleName"].ToString();
                string lname = reader["LastName"].ToString();
                string phone = reader["Phone"].ToString();
                int age = Convert.ToInt32(reader["Age"]);
                int bllodGroupId = Convert.ToInt32(reader["BloodGroupId"]);
                string bloodGroup = reader["BloodGroup"].ToString();
                int areaId = Convert.ToInt32(reader["AreaId"]);
                string area = reader["Area"].ToString();
                int noOfDonation = Convert.ToInt32(reader["NoOfDonation"]);
                string lastDonationDate = reader["LastDonationDate"].ToString();

                DonorViewModel donor = new DonorViewModel();
                donor.Id = id;
                donor.Username = username;
                donor.Password = password;
                donor.FirstName = fname;
                donor.MiddleName = mname;
                donor.LastName = lname;
                donor.Phone = phone;
                donor.Age = age;
                donor.BloodGroupId = bllodGroupId;
                donor.BloodGroup = bloodGroup;
                donor.Area = area;
                donor.AreaId = areaId;
                donor.NumberOfDonation = noOfDonation;
                donor.LastDonationDate = lastDonationDate;

                donorsList.Add(donor);
            }
            return donorsList;
        }

        public List<Donor> GetAllPossibleDonorsForDonation()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query =
                "select Donor.id as Id, Donor.UserName as Username, Donor.FirstName as " +
                " FirstName, Donor.MiddleName as MiddleName, Donor.LastName as LastName, Donor.Phone as Phone," +
                "Donor.BloodGroupId as BloodGroupId, Donor.AreaId as AreaId, Donor.GenderId as GenderId, Donor.NoOfDonation as " +
                "NoOfDonation, Donor.LastDonationDate as LastDonationDate, BloodGroup.BloodGroup as BloodGroup from Donor left outer join BloodGroup on Donor.BloodGroupId=BloodGroup.Id";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Donor> donorsList = new List<Donor>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string username = reader["UserName"].ToString();
                string fname = reader["FirstName"].ToString();
                string mname = reader["MiddleName"].ToString();
                string lname = reader["LastName"].ToString();
                string phone = reader["Phone"].ToString();
                int bllodGroupId = Convert.ToInt32(reader["BloodGroupId"]);
                int areaId = Convert.ToInt32(reader["AreaId"]);
                int genderId = Convert.ToInt32(reader["GenderId"]);
                int noOfDonation = Convert.ToInt32(reader["NoOfDonation"]);
                string lastDonationDate = reader["LastDonationDate"].ToString();
                string bloodGroupName = reader["BloodGroup"].ToString();

                Donor donor = new Donor();
                donor.Id = id;
                donor.Username = username;
                donor.FirstName = fname;
                donor.MiddleName = mname;
                donor.LastName = lname;
                donor.Phone = phone;
                donor.BloodGroup = bllodGroupId;
                donor.Area = areaId;
                donor.Gender = genderId;
                donor.NumberOfDonation = noOfDonation;
                donor.LastDonationDate = lastDonationDate;
                donor.BLoodGroupName = bloodGroupName;

                donorsList.Add(donor);
            }
            return donorsList;
        }

        public bool Update(Donor donor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update Donor SET Phone=@phone, AreaId=@area, Pass=@password, " +
                           "NoOfDonation=@noOfDonation, LastDonationDate=@lastDonationDate " +
                           "Where Donor.Id=@id";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("id", SqlDbType.Int);
            command.Parameters["id"].Value = donor.Id;
           
            command.Parameters.Add("phone", SqlDbType.VarChar);
            command.Parameters["phone"].Value = donor.Phone;

            command.Parameters.Add("area", SqlDbType.Int);
            command.Parameters["area"].Value = donor.Area;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = donor.Password;

            command.Parameters.Add("noOfDonation", SqlDbType.Int);
            command.Parameters["noOfDonation"].Value = donor.NumberOfDonation;

            command.Parameters.Add("lastDonationDate", SqlDbType.VarChar);
            command.Parameters["lastDonationDate"].Value = donor.LastDonationDate;


            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected>0;
        }
        public bool UpdatePassword(ResetPasswordViewModel donor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update Donor SET UserName=@username, Pass=@password " +                           
                           "Where Donor.Phone=@phone";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();


            command.Parameters.Add("username", SqlDbType.VarChar);
            command.Parameters["username"].Value = donor.Username;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = donor.Password;

            command.Parameters.Add("phone", SqlDbType.VarChar);
            command.Parameters["phone"].Value = donor.Phone;        
          

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected > 0;
        }

        public bool ResetPasswordIsUsernameUnique(Donor donor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Donor where Username=@username AND Phone!=@phone";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("username", SqlDbType.VarChar);
            command.Parameters["username"].Value = donor.Username;

            command.Parameters.Add("phone", SqlDbType.VarChar);
            command.Parameters["phone"].Value = donor.Phone;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int InsertBloodRequestInformation(NeedBloodModel patient)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO NeedBloodRequestTable (Name, Phone, AreaId, BloodGroupId, " +
                           "Address, GenderId, Disease, Age) " +
                           "VALUES (@name, @phone, @area, " +
                           "@bloodgroup, @address, @gender, @disease,  @age)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = patient.Name;          

            command.Parameters.Add("gender", SqlDbType.Int);
            command.Parameters["gender"].Value = patient.Gender;

            command.Parameters.Add("age", SqlDbType.Int);
            command.Parameters["age"].Value = patient.Age;

            command.Parameters.Add("bloodgroup", SqlDbType.Int);
            command.Parameters["bloodgroup"].Value = patient.BloodGroup;

            command.Parameters.Add("phone", SqlDbType.VarChar);
            command.Parameters["phone"].Value = patient.Phone;

            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = patient.Adrees;

            command.Parameters.Add("area", SqlDbType.Int);
            command.Parameters["area"].Value = patient.Area;

            command.Parameters.Add("disease", SqlDbType.VarChar);
            command.Parameters["disease"].Value = patient.Disease;
          
            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }

        public List<NeedBloodViewModel> GetAllRequest()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select NeedBloodRequestTable.Id as Id, NeedBloodRequestTable.Name " +
                           "as Name, NeedBloodRequestTable.Phone as Phone, NeedBloodRequestTable.Address " +
                           "as Address, NeedBloodRequestTable.Disease as Disease, NeedBloodRequestTable.Age " +
                           "as Age, NeedBloodRequestTable.RequestDate as RequestDate, BloodGroup.Id " +
                           "as BloodGroupId, BloodGroup.BloodGroup as BloodGroup, Area.Id as AreaId, " +
                           "Area.Area as Area, DonorGender.Gender as Gender from NeedBloodRequestTable " +
                           "left outer join BloodGroup on NeedBloodRequestTable.BloodGroupId=BloodGroup.Id left outer join Area on " +
                            "NeedBloodRequestTable.AreaId=Area.Id left outer join DonorGender on NeedBloodRequestTable.GenderId=DonorGender.Id";              

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<NeedBloodViewModel> needBloodRequestList = new List<NeedBloodViewModel>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Name"].ToString();
                string phone = reader["Phone"].ToString();               
                int age = Convert.ToInt32(reader["Age"]);
                int bllodGroupId = Convert.ToInt32(reader["BloodGroupId"]);
                string bloodGroup = reader["BloodGroup"].ToString();
                int areaId = Convert.ToInt32(reader["AreaId"]);
                string gender = reader["Gender"].ToString();
                string area = reader["Area"].ToString();
                string address = reader["Address"].ToString();
                string disease = reader["Disease"].ToString();
                string requestdate = reader["RequestDate"].ToString();
                

                NeedBloodViewModel needBloodView = new NeedBloodViewModel();
                needBloodView.Id = id;
                needBloodView.Name = name;               
                needBloodView.Phone = phone;
                needBloodView.Age = age;
                needBloodView.BloodGroupId = bllodGroupId;
                needBloodView.BloodGroup = bloodGroup;
                needBloodView.Area = area;
                needBloodView.Gender = gender;
                needBloodView.AreaId = areaId;
                needBloodView.Disease = disease;
                needBloodView.Address = address;
                needBloodView.RequestDate = requestdate;

                needBloodRequestList.Add(needBloodView);
            }
            return needBloodRequestList;
        }

    }
}