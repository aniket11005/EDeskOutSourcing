using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class FreelancerFAQController : Controller
    {
        CompanyContext cc;
        public FreelancerFAQController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.FreelancerFAQs.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FreelancerFAQ rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.FreelancerFAQs.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "FreelancerFAQ", new { area = "AdminArea" });
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.FreelancerFAQs.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(FreelancerFAQ rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "FreelancerFAQ", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.FreelancerFAQs.Find(id);
            this.cc.FreelancerFAQs.Remove(rec);
            this.cc.SaveChanges();
            return View("Index");
        }
    }
}
