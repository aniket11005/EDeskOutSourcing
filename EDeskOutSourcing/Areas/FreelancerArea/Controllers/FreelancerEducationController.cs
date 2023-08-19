using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class FreelancerEducationController : Controller
    {
        CompanyContext cc;
        public  FreelancerEducationController(CompanyContext cnc)
        {
           this.cc = cnc;
        }
        public IActionResult Index()
        {
            var v = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            var rec = this.cc.FreelancerEducations.Where(p => p.FreelancerID == v).ToList();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.EID = new SelectList(this.cc.Educations.ToList(), "EducationID", "EducationName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(FreelancerEducation rec,Int64[]EName, string[] PName, string[]UName)
        {
            ViewBag.EID = new SelectList(this.cc.Educations.ToList(), "EducationID", "EducationName");
            ViewBag.FID = new SelectList(this.cc.Freelancers.ToList(), "FreelancerID", "FreelancerName");

            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));

            List<FreelancerEducation> fe = new List<FreelancerEducation>();

            for (int i = 0; i < PName.Length; i++)
            {
                FreelancerEducation srec = new FreelancerEducation();
                try
                {
                    srec.FreelancerID = cid;
                    srec.EducationID = EName[i];
                    srec.PassingYear = PName[i];
                    srec.UniversityInstituteName = UName[i];
                    fe.Add(srec);

                }
                catch
                {
                    break;
                }
            }
            foreach (var item in fe)
            {
                cc.FreelancerEducations.Add(item);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.EID = new SelectList(this.cc.Educations.ToList(), "EducationID", "EducationName");
            var rec = this.cc.FreelancerEducations.Find(id);
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(FreelancerEducation rec)
        {
            ViewBag.EID = new SelectList(this.cc.Educations.ToList(), "EducationID", "EducationName");

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
            var rec = this.cc.FreelancerEducations.Find(id);
            this.cc.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
