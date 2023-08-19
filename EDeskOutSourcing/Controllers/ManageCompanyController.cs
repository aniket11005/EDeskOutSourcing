using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EDeskOutSourcing.Controllers
{
    public class ManageCompanyController : Controller
    {
        CompanyContext cc;
        public ManageCompanyController(CompanyContext asp)
        {
            this.cc = asp;
        }
        public IActionResult Index()
        {
            ViewBag.CityID = new SelectList(this.cc.Cities.ToList(), "CityID", "CityName");
            return View();
        }
        [HttpGet]
        public IActionResult Register()        
        {
            ViewBag.CityID = new SelectList(this.cc.Cities.ToList(), "CityID", "CityName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(Company rec)
        {
            ViewBag.CityID = new SelectList(this.cc.Cities.ToList(), "CityID", "CityName");

            if (ModelState.IsValid)
            {
                this.cc.Companies.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("SignIn", "ManageCompany", new {area=""});
            }
            return View(rec);
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

                var srec = this.cc.Companies.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if (srec != null)
                {
                    HttpContext.Session.SetString("CompanyName", srec.CompanyName);
                    HttpContext.Session.SetString("CompanyID", srec.CompanyID.ToString());
                    return RedirectToAction("Index", "CompanyHome", new { area = "CompanyArea" });
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid EmailID or Password");
                    return View(rec);
                }
            }
            return View(rec);
        }
        public IActionResult Signout()
        {
            this.HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
