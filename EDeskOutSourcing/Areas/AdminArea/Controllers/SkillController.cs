using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SkillController : Controller
    {
        CompanyContext cc;
        public SkillController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.Skills.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Skill rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Skills.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Skill", new { area = "AdminArea" });
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.Skills.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Skill rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Skill", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Skills.Find(id);
            this.cc.Skills.Remove(rec);
            this.cc.SaveChanges();
            return View("Index");
        }
    }
}
