using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ProjectController : Controller
    {
        CompanyContext cc;
        public ProjectController(CompanyContext tcs)
        {
            this.cc = tcs;
        }
        public IActionResult Index()
        {
            var v = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var rec= this.cc.Projects.Where(p=>p.CompanyID==v).ToList();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CID = new SelectList(this.cc.Companies.ToList(), "CompanyID", "CompanyName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project rec)
        {
            ViewBag.CID = new SelectList(this.cc.Companies.ToList(),"CompanyID", "CompanyName");
            rec.CompanyID=Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            this.cc.Projects.Add(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.CompanyID = new SelectList(this.cc.Companies.ToList(), "CompanyID", "CompanyName");
            var rec=this.cc.Projects.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(Project rec)
        {
            if(ModelState.IsValid)
            {
                ViewBag.CompanyID = new SelectList(this.cc.Companies.ToList(), "CompanyID", "CompanyName");
                this.cc.Entry(rec).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        public ActionResult Delete(Int64 id)
        {
            var rec = this.cc.Projects.Find(id);
            this.cc.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
