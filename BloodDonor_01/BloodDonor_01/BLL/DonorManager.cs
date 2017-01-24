using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodDonor_01.DAL;
using BloodDonor_01.Models;

namespace BloodDonor_01.BLL
{
    public class DonorManager
    {
        DonorGateway donorGateway=new DonorGateway();
        public string Insert(Donor donor)
        {
            string message = "Insertion Faield";

            bool isUsernameUnique = donorGateway.IsUsernameUnique(donor);
            bool isPhoneUnique = donorGateway.IsPhoneUnique(donor);

            if (isUsernameUnique)
            {
                message = "Username already taken. Try another.";
                return message;
            }

            else
            {
                if (isPhoneUnique)
                {
                    message = "Phone number already exist";
                    return message;
                }
                else
                {
                     int isSaved = donorGateway.Insert(donor);
                     if (isSaved > 0)
                     {
                          message = "Registraion Successful. Want to edit profile?";
                     }
                     return message;
                }
                
            }

        }

        public List<BloodGroup> GetAllBloodGroups()
        {
            return donorGateway.GetAllBloodGroups();
        }

        public List<Gender> GetAllGenders()
        {
            return donorGateway.GetAllGenders();
        }

        public List<Area> GetAllAreas()
        {
            return donorGateway.GetAllAreas();
        }

        public List<DonorViewModel> GetAllDonors()
        {
            return donorGateway.GetAllDonors();
        }

        public List<DonorViewModel> GetLastTweentyDonors()
        {
           List<DonorViewModel> donorList= donorGateway.GetAllDonors();
            List<DonorViewModel> sortedDonorsList = donorList.OrderByDescending(m => m.Id).ToList();
            List<DonorViewModel> lastTweentyDonors = sortedDonorsList.Take(20).ToList();

            return lastTweentyDonors;
        }

        public List<Donor> GetAllPossibleDonorsForDonation()
        {
            List<Donor> donorsList = donorGateway.GetAllPossibleDonorsForDonation();

            List<Donor> allPossibleDonorsList = new List<Donor>();
            foreach (var donor in donorsList)
            {
                DateTime endTime = DateTime.Now;
                DateTime startTime = Convert.ToDateTime(donor.LastDonationDate);
                TimeSpan timeSpan = endTime.Subtract(startTime);
                int time = timeSpan.Days;
                if (donor.Gender == 1 && time > 95 || donor.Gender == 2 && time > 125)
                {
                    allPossibleDonorsList.Add(donor);
                }
            }
            return allPossibleDonorsList;
        }

        public string Update(Donor donor)
        {
            bool isUpdated = donorGateway.Update(donor);
            string message = "Update Failed!";
            if (isUpdated)
            {
                message = "Updated Successfully!";
            }

            return message;
        }

        public string UpdatePassword(ResetPasswordViewModel donor)
        {
            Donor aDonor=new Donor();
            aDonor.Username = donor.Username;
            aDonor.Phone = donor.Phone;
            string message = "Update Failed!";
            bool isUsernameUnique = donorGateway.ResetPasswordIsUsernameUnique(aDonor);
            
            if (isUsernameUnique)
            {
                message = "Username already taken. Try another.";
                return message;
            }
            else
            {
                bool isUpdated = donorGateway.UpdatePassword(donor);
                if (isUpdated)
                {
                    message = "Reset Successful!";
                }
            }
           

            return message;
        }

        public string InsertBloodRefuestInfo(NeedBloodModel patient)
        {
            string message = "Request Faield";

            int isSaved = donorGateway.InsertBloodRequestInformation(patient);
                    if (isSaved > 0)
                    {
                        message = "Request accepted and recorded";
                    }
                    
                    return message;
        }

        public List<NeedBloodViewModel> GetLastFiveDaysRequest()
        {
            List<NeedBloodViewModel> requestList = donorGateway.GetAllRequest();

            List<NeedBloodViewModel> allRequestList = new List<NeedBloodViewModel>();
            foreach (var request in requestList)
            {
                DateTime endTime = DateTime.Now;
                DateTime startTime = Convert.ToDateTime(request.RequestDate);
                TimeSpan timeSpan = endTime.Subtract(startTime);
                int time = timeSpan.Days;
                if (time <= 5)
                {
                    allRequestList.Add(request);
                }
            }
            return allRequestList;
        }

        public List<NeedBloodViewModel> GetLastMonthRequest()
        {
            List<NeedBloodViewModel> requestList = donorGateway.GetAllRequest();

            List<NeedBloodViewModel> allRequestList = new List<NeedBloodViewModel>();
            foreach (var request in requestList)
            {
                DateTime endTime = DateTime.Now;
                DateTime startTime = Convert.ToDateTime(request.RequestDate);
                TimeSpan timeSpan = endTime.Subtract(startTime);
                int time = timeSpan.Days;
                if (time <= 30)
                {
                    allRequestList.Add(request);
                }
            }
            return allRequestList;
        }
                  
    }
}