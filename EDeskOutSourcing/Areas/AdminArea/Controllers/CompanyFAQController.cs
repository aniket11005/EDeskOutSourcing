using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CompanyFAQController : Controller
    {
        CompanyContext cc;
        public CompanyFAQController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.CompanyFAQs.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CompanyFAQ rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.CompanyFAQs.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "CompanyFAQ", new { area = "AdminArea" });
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.CompanyFAQs.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(CompanyFAQ rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "CompanyFAQ", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.CompanyFAQs.Find(id);
            this.cc.CompanyFAQs.Remove(rec);
            this.cc.SaveChanges();
            return View(rec);
        }
    }
}
