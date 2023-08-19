using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SkillCategoryController : Controller
    {
        CompanyContext cc;
        public SkillCategoryController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.SkillCategories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SkillCategory rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.SkillCategories.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "SkillCategory", new { area = "AdminArea" });
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.SkillCategories.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(SkillCategory rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "SkillCategory", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.SkillCategories.Find(id);
            this.cc.SkillCategories.Remove(rec);
            this.cc.SaveChanges();
            return View("Index");
        }
    }
}
