using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    
    public class TermsAndConditionForCompanyController : Controller
    {
        CompanyContext css;
        public TermsAndConditionForCompanyController(CompanyContext tntx)
        {
            this.css = tntx;
        }
        public IActionResult Index()
        {
            return View(css.TermsAndConditionForCompanies.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TermsAndConditionForCompany rec)
        {
                this.css.TermsAndConditionForCompanies.Add(rec);
                this.css.SaveChanges();
                return RedirectToAction("Index", "TermsAndConditionForCompany", new { area = "AdminArea" });
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.css.TermsAndConditionForCompanies.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(TermsAndConditionForCompany rec)
        {
            if (ModelState.IsValid)
            {
                this.css.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.css.SaveChanges();
                return RedirectToAction("Index", "TermsAndConditionForCompany", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.css.TermsAndConditionForCompanies.Find(id);
            this.css.TermsAndConditionForCompanies.Remove(rec);
            this.css.SaveChanges();
            return View("Index");
        }
    }
}
