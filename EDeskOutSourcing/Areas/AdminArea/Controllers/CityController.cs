using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CityController : Controller
    {
        CompanyContext cc;
        public CityController(CompanyContext css)
        {
            this.cc = css;
        }
        public IActionResult Index()
        {
            return View(cc.Cities.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StateID=new SelectList(cc.States.ToList(),"StateID","StateName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(City crec)
        {
            ViewBag.StateID = new SelectList(cc.States.ToList(), "StateID", "StateName");
            if (ModelState.IsValid)
            {
                this.cc.Cities.Add(crec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "City", new {area="AdminArea"});
            }
            return View(crec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.StateID = new SelectList(cc.States.ToList(), "StateID", "StateName");
            var rec = this.cc.Cities.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(City rec)
        {
            if (ModelState.IsValid)
            {
                ViewBag.StateID = new SelectList(cc.States.ToList(), "StateID", "StateName");
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Cities.Find(id);
            this.cc.Cities.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
