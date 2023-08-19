using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EDeskOutSourcing.Controllers
{
    public class ManageAdminController : Controller
    {
        CompanyContext cc;
        public ManageAdminController(CompanyContext cnc)
        {
            this.cc = cnc;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInVM rec)
        {
            if (ModelState.IsValid)
            {
                var srec = cc.Admins.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if (srec != null)
                {
                    HttpContext.Session.SetString("AdminName", srec.AdminName);
                    HttpContext.Session.SetString("AdminID", srec.AdminID.ToString());
                    return RedirectToAction("Index", "AdminHome", new {area="AdminArea"});
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Email Id Or Passwod!");
                    return View(rec);
                }
            }
            return View(rec);
        }
        public  IActionResult Signout()
        {
            this.HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
