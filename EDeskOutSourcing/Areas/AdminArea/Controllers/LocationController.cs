using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class LocationController : Controller
    {
        CompanyContext cc;
        public LocationController (CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(cc.Locations.ToList()) ;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CityID=new SelectList(cc.Cities.ToList(),"CityID","CityName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location rec)
        {
            ViewBag.CityID = new SelectList(cc.Cities.ToList(), "CityID", "CityName");
            if (ModelState.IsValid)
            {
                cc.Locations.Add(rec);
                cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.CityID = new SelectList(cc.Cities.ToList(), "CityID", "CityName");
            var rec=this.cc.Locations.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Location rec)
        {
            if(ModelState.IsValid)
            {
                ViewBag.CityID = new SelectList(cc.Cities.ToList(), "CityID", "CityName");
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Locations.Find(id);
            this.cc.Locations.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index"); ;
        }
    }
}
