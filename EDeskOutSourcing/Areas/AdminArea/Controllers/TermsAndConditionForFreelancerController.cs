using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TermsAndConditionForFreelancerController : Controller
    {
        CompanyContext css;
        public TermsAndConditionForFreelancerController(CompanyContext tntx)
        {
            this.css = tntx;
        }
        public IActionResult Index()
        {
            return View(css.TermsAndConditionForFreelancers.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TermsAndConditionForFreelancer rec)
        {
            if(ModelState.IsValid)
            {
                this.css.TermsAndConditionForFreelancers.Add(rec);
                this.css.SaveChanges();
                return RedirectToAction("Index", "TermsAndConditionForFreelancer", new {area="AdminArea"});
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec=this.css.TermsAndConditionForFreelancers.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(TermsAndConditionForFreelancer rec)
        {
            if(ModelState.IsValid)
            {
                this.css.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.css.SaveChanges();
                return RedirectToAction("Index", "TermsAndConditionForFreelancer", new {area="AdminArea"});
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.css.TermsAndConditionForFreelancers.Find(id);
            this.css.TermsAndConditionForFreelancers.Remove(rec);
            this.css.SaveChanges();
            return View("Index");
        }
    }
}
