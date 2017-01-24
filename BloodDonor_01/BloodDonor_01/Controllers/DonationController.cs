using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodDonor_01.BLL;
using BloodDonor_01.Models;
using BloodDonor_01.OnnoRokomSms;

namespace BloodDonor_01.Controllers
{
    public class DonationController : Controller
    {
        DonorManager donorManager=new DonorManager();

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult WhyBloodDonation()
        {
            return View();
        }

        public ActionResult EligibilityForDonation()
        {
            return View();
        }

        public ActionResult TipsOnDonation()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.listOfBloodGroups = donorManager.GetAllBloodGroups();
            ViewBag.listOfGenders = donorManager.GetAllGenders();
            ViewBag.listOfAreas = donorManager.GetAllAreas();
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Donor bloodDonor)
        {
            ViewBag.listOfBloodGroups = donorManager.GetAllBloodGroups();
            ViewBag.listOfGenders = donorManager.GetAllGenders();
            ViewBag.listOfAreas = donorManager.GetAllAreas();
            if (bloodDonor.LastDonationDate == null)
            {
                DateTime nowTime = DateTime.Today;
                DateTime donationTime = nowTime.AddMonths(-5);
                bloodDonor.LastDonationDate = donationTime.ToString("MM/dd/yyyy");
            }
            string message = donorManager.Insert(bloodDonor);
            ViewBag.Message = message;
            return View();
        }       

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("LogIn", "Donation");
            }
            
            return View();
        }

        public ActionResult LogIn()
        {        
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {        
            List<DonorViewModel> donorsList= donorManager.GetAllDonors();
            LogInViewModel aLogInViewModel=new LogInViewModel();
           
            foreach (var donor in donorsList)
            {
                
                if (donor.Username.Equals(username) && donor.Password.Equals(password))
                {
                    Session["user"] = new DonorViewModel()
                    {
                        Username = username,
                        Id = donor.Id,
                        FirstName = donor.FirstName,
                        MiddleName = donor.MiddleName,
                        LastName = donor.LastName,
                        Phone = donor.Phone,
                        BloodGroup = donor.BloodGroup,
                        Area = donor.Area,
                        NumberOfDonation = donor.NumberOfDonation,
                        LastDonationDate = donor.LastDonationDate,
                        Password = donor.Password
                      
                    };
                    if (aLogInViewModel.RememberMe)
                    {
                        HttpCookie userCookie01 = new HttpCookie(donor.Username);                     
                        Response.Cookies.Add(userCookie01);
                        HttpCookie userCookie02 = new HttpCookie(donor.Password);
                        Response.Cookies.Add(userCookie02);

                    }
                    return RedirectToAction("Index", "Donation");
                }
                else
                {
                    string msg= "incorrect username or password ";
                    ViewBag.message = msg;
                }
            }     
            return View();
        }

        public ActionResult LogOut()
        {
           Session.Clear();
           return RedirectToAction("LogIn", "Donation");
        }

        public ActionResult NeedBlood()
        {
            ViewBag.listOfBloodGroups = donorManager.GetAllBloodGroups();
            ViewBag.listOfGenders = donorManager.GetAllGenders();
            ViewBag.listOfAreas = donorManager.GetAllAreas();
            
            return View();           
        }

        [HttpPost]
        public ActionResult NeedBlood(NeedBloodModel patient)
        {
            ViewBag.listOfBloodGroups = donorManager.GetAllBloodGroups();
            ViewBag.listOfGenders = donorManager.GetAllGenders();
            ViewBag.listOfAreas = donorManager.GetAllAreas();
            string message = donorManager.InsertBloodRefuestInfo(patient);
            ViewBag.Message = message;
            List<string> donorMobileList = new List<string>();
            List<string> donorName = new List<string>();
            string bloodGroup = "";
            List<Donor> allDonors = donorManager.GetAllPossibleDonorsForDonation();
            List<Donor> donorListForCollector=new List<Donor>();
            foreach (var donor in allDonors)
            {
                if (donor.Area == patient.Area && donor.BloodGroup == patient.BloodGroup)
                {
                    donorListForCollector.Add(donor);
                    donorMobileList.Add(donor.Phone);
                    donorName.Add(donor.FirstName + " " + donor.MiddleName + " " + donor.LastName);
                    bloodGroup = donor.BLoodGroupName;
                }
            }
            var sms = new SendSmsSoapClient();

            var messageHeader = new MessageHeader();
            messageHeader.UserName = "01680358860";
            messageHeader.UserPassword = "Akmal2494";
            messageHeader.CampingName = "";
            messageHeader.MarskText = "BloodDonor";
            WsSms[] arrayList = new WsSms[donorMobileList.Count];
            for (int i = 0; i < donorMobileList.Count; i++)
            {
                var wSms = new WsSms();
                wSms.MobileNumber = donorMobileList[i];
                wSms.SmsText = "Dear " + donorName[i] + ", one patient need blood.\nPlease Contact:\nBlood Group: " + bloodGroup + "\nContact: " + patient.Phone+"\n\nPlease update profile after your every donation";
                wSms.Type = "TEXT";
                arrayList[i] = wSms;
            }
         
            var returnResult = sms.OneToOneBulk(messageHeader, arrayList);
            ViewBag.MessageSMS = returnResult;

            List<Donor> donorListForCollectorView= donorListForCollector.OrderByDescending(m => m.NumberOfDonation).ToList();
            List<Donor> donors = donorListForCollectorView.Take(10).ToList();
            ViewBag.TopDonorList = donors;

            return View();
            
        }

        public ActionResult Edit()
        {
            ViewBag.listOfBloodGroups = donorManager.GetAllBloodGroups();
            
            ViewBag.listOfAreas = donorManager.GetAllAreas();
            
            return View();
        }

        [HttpPost]
         public ActionResult Edit(Donor donor)
        {
            ViewBag.listOfBloodGroups = donorManager.GetAllBloodGroups();
            ViewBag.listOfAreas = donorManager.GetAllAreas();            
            string message = donorManager.Update(donor);

            ViewBag.Message = message;

            return RedirectToAction("Index", "Donation");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel donor)
        {
            string message = donorManager.UpdatePassword(donor);
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ViewAllDonorsByBloodGroup()
        {
            var allAreaList = donorManager.GetAllAreas();
            var bloodGrouptList = donorManager.GetAllBloodGroups();
            ViewBag.ALLDepartment = bloodGrouptList;
            ViewBag.AllArea = allAreaList;

            return View();
        }

        public ActionResult ViewAllDonorsByArea()
        {
            var allAreaList = donorManager.GetAllAreas();
            var bloodGrouptList = donorManager.GetAllBloodGroups();
            ViewBag.ALLDepartment = bloodGrouptList;
            ViewBag.AllArea = allAreaList;

            return View();
        }
        public JsonResult GetAllDonorInfoForShow(int bloodGroupId)
        {
            var donorList = donorManager.GetAllDonors();
            var allDonorsList = donorList.Where(m => m.BloodGroupId == bloodGroupId).ToList();
            var allDonors = allDonorsList.OrderByDescending(m => m.NumberOfDonation).ToList();
            
            return Json(allDonors, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDonorForShow(int areaId)
        {
            var donorList = donorManager.GetAllDonors();
            var allDonorsList = donorList.Where(m => m.AreaId == areaId).ToList();
            var allDonors = allDonorsList.OrderByDescending(m => m.NumberOfDonation).ToList();

            return Json(allDonors, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllPossibleDonor(int bloodGroup)
        {
            var donorList = donorManager.GetAllPossibleDonorsForDonation();
            var allPossibleDonors = donorList.Where(m => m.BloodGroup == bloodGroup).ToList();

            return Json(allPossibleDonors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindTopDonors()
        {
            List<DonorViewModel> donorList = donorManager.GetAllDonors();
            List<DonorViewModel> sortedDonorList = donorList.OrderByDescending(m => m.NumberOfDonation).ToList();
            List<DonorViewModel> topTenDonorsList = sortedDonorList.Take(10).ToList();           

            ViewBag.topTenDonors = topTenDonorsList;

            return View();
        }

        public ActionResult LastFiveDaysRequest()
        {
            var bloodGrouptList = donorManager.GetAllBloodGroups();
            List<NeedBloodViewModel> requestList = donorManager.GetLastFiveDaysRequest();
            List<NeedBloodViewModel> recentRequestList = requestList.OrderByDescending(m => m.Id).ToList();

            ViewBag.lastFiveDaysRequest = recentRequestList;
            ViewBag.bloodGroupList = bloodGrouptList;

            return View();
        }

        public JsonResult GetAllRequestOnBloodGroup(int bloodGroupId)
        {
            var requestList = donorManager.GetLastFiveDaysRequest();
            var allRequest = requestList.Where(m => m.BloodGroupId == bloodGroupId).ToList();
            var allRecentRequestList = allRequest.OrderByDescending(m => m.Id).ToList();

            return Json(allRecentRequestList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastMonthRequests()
        {
            var bloodGrouptList = donorManager.GetAllBloodGroups();
            List<NeedBloodViewModel> requestLists = donorManager.GetLastMonthRequest();
            List<NeedBloodViewModel> recentRequestList = requestLists.OrderByDescending(m => m.Id).ToList();

            ViewBag.lastMonthRequests = recentRequestList;
            ViewBag.bloodGroupList = bloodGrouptList;
            return View();
        }

        public JsonResult GetLastMonthsRequestOnBloodGroup(int bloodGroupId)
        {
            var requestList = donorManager.GetLastMonthRequest();
            var allRequest = requestList.Where(m => m.BloodGroupId == bloodGroupId).ToList();
            var allRecentRequestList = allRequest.OrderByDescending(m => m.Id).ToList();

            return Json(allRecentRequestList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RecentRegisteredDonors()
        {
            List<DonorViewModel> lastTweentyDonors = donorManager.GetLastTweentyDonors();
            ViewBag.lastTweentyDonorsList = lastTweentyDonors;

            return View();
        }

        public ActionResult DonorGuide()
        {
            return View();
        }

	}
}