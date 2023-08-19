using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EducationController : Controller
    {
        CompanyContext cc;
        public EducationController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.Educations.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Education rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Educations.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Education", new { area = "AdminArea" });
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.Educations.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Education rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Education", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Educations.Find(id);
            this.cc.Educations.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
