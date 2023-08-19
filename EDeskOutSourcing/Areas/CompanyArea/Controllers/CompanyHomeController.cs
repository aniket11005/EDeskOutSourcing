using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class CompanyHomeController : Controller
    {
        CompanyContext cc;
        public CompanyHomeController(CompanyContext ccs)
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
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                var srec = cc.Companies.SingleOrDefault(p => p.CompanyID == cid && p.Password == rec.OldPassword);
                if (srec != null)
                {
                    srec.Password = rec.NewPassword;
                    this.cc.SaveChanges();
                    ViewBag.Message = "Password Changed Successfully!!";
                    return RedirectToAction("SignIn", "ManageCompany", new { area = "" });
                }

                ViewBag.Message = "Invalid Old Password!!";
                return View(rec);

            }

            return View(rec);
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            Int64 cid=Convert.ToInt64(HttpContext.Session.GetString("CompanyID".ToString()));
            var rec = from t in cc.Companies
                      where t.CompanyID == cid
                      select new CompanyVM
                      {
                          CompanyName = t.CompanyName,
                          Address = t.Address,
                          MobileNo = t.MobileNo,
                          ContactPersonName = t.ContactPersonName
                      };
            return View(rec.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult EditProfile(CompanyVM rec)
        {
            ViewBag.Message = "";
            if(ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID".ToString()));
                var urec = cc.Companies.Find(cid);
                urec.CompanyName = rec.CompanyName;
                urec.Address = rec.Address;
                urec.MobileNo = rec.MobileNo;
                urec.ContactPersonName = rec.ContactPersonName;
                this.cc.SaveChanges();
                ViewBag.Message = "Profile Updated Successfully";
                return RedirectToAction("Index", "CompanyHome", new {area="CompanyArea"});
            }
            return View(rec);
        }
    }
}
