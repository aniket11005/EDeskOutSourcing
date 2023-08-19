using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TechnologiesController : Controller
    {
        CompanyContext cc;
        public TechnologiesController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.Technologies.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Technologies rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Technologies.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Technologies", new { area = "AdminArea" });
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.Technologies.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Technologies rec)
        {
            if (ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Technologies", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Technologies.Find(id);
            this.cc.Technologies.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
