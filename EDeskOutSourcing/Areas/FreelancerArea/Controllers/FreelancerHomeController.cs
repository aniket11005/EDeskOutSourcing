using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class FreelancerHomeController : Controller
    {
        CompanyContext cc;
        public FreelancerHomeController(CompanyContext ccs)
        {
            this.cc = ccs;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 aid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
                var srec = cc.Freelancers.SingleOrDefault(p => p.FreelancerID == aid && p.Password == rec.OldPassword);
                if (srec != null)
                {
                    srec.Password = rec.NewPassword;
                    this.cc.SaveChanges();
                    ViewBag.Message = "Password Changed Successfully!!";
                    return RedirectToAction("SignIn", "ManageFreelancer", new { area = "" });
                }

                ViewBag.Message = "Invalid Old Password!!";
                return View(rec);

            }

            return View(rec);
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            Int64 fid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID".ToString()));
            var rec = from t in cc.Freelancers
                      where t.FreelancerID == fid
                      select new FreelancerVM
                      {
                          FirstName = t.FirstName,
                          LastName = t.LastName,
                          Address = t.Address,
                          MobileNo = t.MobileNo,
                      };
            return View(rec.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult EditProfile(FreelancerVM rec)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                Int64 fid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID".ToString()));
                var urec = cc.Freelancers.Find(fid);
                urec.FirstName = rec.FirstName;
                urec.LastName = rec.LastName;
                urec.Address = rec.Address;
                urec.MobileNo = rec.MobileNo;
                this.cc.SaveChanges();
                ViewBag.Message = "Profile Updated Successfully";
                return RedirectToAction("Index", "FreelancerHome", new { area = "FreelancerArea" });
            }
            return View(rec);
        }

    }
}
