using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CountryController : Controller
    {
        CompanyContext cc;
        public CountryController(CompanyContext ccs)
        {
            this.cc = ccs;
        }
        public IActionResult Index()
        {
            return View(cc.Countries.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Country rec) 
        {
            if(ModelState.IsValid)
            {
                this.cc.Countries.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Country", new {area="AdminArea"});
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit( Int64 id)
        {
            var rec = this.cc.Countries.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Country rec)
        {
            if(ModelState.IsValid)
            {
                this.cc.Entry(rec).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "Country", new {area="AdminArea"});
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.Countries.Find(id);
            this.cc.Countries.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
