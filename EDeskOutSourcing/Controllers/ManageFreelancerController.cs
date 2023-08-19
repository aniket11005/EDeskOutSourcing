using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EDeskOutSourcing.Controllers
{
    public class ManageFreelancerController : Controller
    {
        CompanyContext cc;
        public ManageFreelancerController(CompanyContext asp)
        {
            this.cc = asp;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Freelancer rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Freelancers.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("SignIn", "ManageFreelancer", new {area=""});
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
            if(ModelState.IsValid)
            {

                var srec = this.cc.Freelancers.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if (srec != null)
                {
                    HttpContext.Session.SetString("FirstName", srec.FirstName.ToString());
                    HttpContext.Session.SetString("FreelancerID", srec.FreelancerID.ToString());
                    return RedirectToAction("Index", "FreelancerHome", new { area = "FreelancerArea" });
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
            return RedirectToAction("SignIn","ManageFreelancer",new {area=""});
        }
    }
}
