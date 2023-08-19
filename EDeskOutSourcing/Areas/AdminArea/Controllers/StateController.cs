using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class StateController : Controller
    {
        CompanyContext cc;
        public StateController(CompanyContext ccs)
        {
            this.cc = ccs;
        }
        public IActionResult Index()
        {
            return View(cc.States.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CountryID = new SelectList(cc.Countries.ToList(),"CountryID","CountryName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(State rec)
        {
            ViewBag.CountryID = new SelectList(cc.Countries.ToList(), "CountryID", "CountryName");
            if (ModelState.IsValid)
            {
                this.cc.States.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.CountryID = new SelectList(cc.Countries.ToList(), "CountryID", "CountryName");
            var rec = this.cc.States.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(State rec)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CountryID = new SelectList(cc.Countries.ToList(), "CountryID", "CountryName");
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.States.Find(id);
            this.cc.States.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
