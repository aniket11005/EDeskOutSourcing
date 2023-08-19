using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using EDeskOutSourcing.CustFilters;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class FreelancerPreviousProjectController : Controller
    {
        CompanyContext cc;
        public FreelancerPreviousProjectController(CompanyContext cnc)
        {
            this.cc = cnc;
        }
        public IActionResult Index()
        {
            var v = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            var rec = this.cc.FreelancerPreviousProjects.Where(p => p.FreelancerID == v).ToList();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FreelancerPreviousProject rec, string[] PName, string[] PDName)
        {
            //ViewBag.FID = new SelectList(this.cc.Freelancers.ToList(), "FreelancerID", "FreelancerName");
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));

            List<FreelancerPreviousProject> fe = new List<FreelancerPreviousProject>();

            for (int i = 0; i < PName.Length; i++)
            {
                if (PName[i] == null)
                {
                    break;
                }
                FreelancerPreviousProject srec = new FreelancerPreviousProject();
                try
                {
                    srec.FreelancerID = cid;
                    srec.ProjectTitle = PName[i];
                    srec.ProjectDescription = PDName[i];
                    fe.Add(srec);

                }
                catch
                {
                    break;
                }
            }
            foreach (var item in fe)
            {
                cc.FreelancerPreviousProjects.Add(item);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.FreelancerPreviousProjects.Find(id);
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(FreelancerPreviousProject rec)
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
            var rec = this.cc.FreelancerPreviousProjects.Find(id);
            this.cc.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
