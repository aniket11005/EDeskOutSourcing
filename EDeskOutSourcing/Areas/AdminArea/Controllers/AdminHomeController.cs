using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]

    public class AdminHomeController : Controller
    {
        CompanyContext cc;
        public AdminHomeController (CompanyContext ccs)
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
            if(ModelState.IsValid)
            {
                Int64 aid= Convert.ToInt64(HttpContext.Session.GetString("AdminID"));
                var srec = cc.Admins.SingleOrDefault(p =>p.AdminID == aid && p.Password == rec.OldPassword);
                if (srec != null)
                {
                    srec.Password = rec.NewPassword;
                    this.cc.SaveChanges();
                    ViewBag.Message = "Password Changed Successfully!!";
                    return RedirectToAction("SignOut", "ManageAdmin", new {area=""});
                }

                ViewBag.Message = "Invalid Old Password!!";
                return View(rec);

            }
           
            return View(rec);
        }
    }
}
