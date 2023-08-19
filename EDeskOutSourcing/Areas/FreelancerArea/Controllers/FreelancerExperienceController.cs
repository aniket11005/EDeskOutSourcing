using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class FreelancerExperienceController : Controller
    {
        CompanyContext cc;
        public FreelancerExperienceController(CompanyContext cnc)
        {
            this.cc = cnc;
        }
        public IActionResult Index()
        {
            var v = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            var rec = this.cc.FreelancerExperiences.Where(p => p.FreelancerID == v).ToList();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FreelancerExperience rec, int[] EName, string[]RName)
        {
            //ViewBag.FID = new SelectList(this.cc.Freelancers.ToList(), "FreelancerID", "FreelancerName");
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            
            List<FreelancerExperience> fe = new List<FreelancerExperience>();
            
            for (int i = 0; i < EName.Length; i++)
            {
                FreelancerExperience srec = new FreelancerExperience();
                try
                {
                    srec.FreelancerID= cid;
                    srec.ExperienceInMonths = EName[i];
                    srec.RoleName = RName[i];
                    fe.Add(srec);

                }
                catch
                {
                    break;
                }
            }
            foreach (var item in fe)
            {
                cc.FreelancerExperiences.Add(item);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec=this.cc.FreelancerExperiences.Find(id);
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(FreelancerExperience rec)
        {
            if(ModelState.IsValid)
            {
                Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        public ActionResult Delete(Int64 id)
        {
            var rec = this.cc.FreelancerExperiences.Find(id);
            this.cc.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");    
        }
       
    }
}
 