using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class FreelancerCertificationsController : Controller
    {
        CompanyContext cc;
        public FreelancerCertificationsController(CompanyContext cnc)
        {
            this.cc = cnc;
        }
        public IActionResult Index()
        {
            var v = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            var rec = this.cc.FreelancerCertifications.Where(p => p.FreelancerID == v).ToList();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FreelancerCertifications rec)
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            ViewBag.FID = cid;
            cc.FreelancerCertifications.Add(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.FreelancerCertifications.Find(id);
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(FreelancerCertifications rec)
        {
            if (ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.FreelancerCertifications.Find(id);
            this.cc.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
