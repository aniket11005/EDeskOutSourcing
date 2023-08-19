using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ProjectStagesController : Controller
    {
        CompanyContext cc;
        public ProjectStagesController(CompanyContext css)
        {
            this.cc = css;
        }
        public IActionResult Index()
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            var x = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));

            var v = from t in cc.Projects
                      where t.CompanyID==x

            //join t1 in cc.Projects
            //on t.ProjectID equals t1.ProjectID

            select new ProjectVM
                    {
                        ProjectName = t.ProjectName,
                        ProjectID=t.ProjectID,
                        NoOfStages= t.ProjectStages.Count()
                    };

            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectStages rec, string[] SName, string[] PName, decimal[] DName)
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            List<ProjectStages> ps= new List<ProjectStages>();
            for (int i = 0;i< SName.Length;i++)
            {
                ProjectStages srec = new ProjectStages();
                try
                {
                    srec.ProjectID = rec.ProjectID;
                    srec.ProjectStagesName = PName[i];
                    srec.DurationInHours = DName[i];
                    srec.StepsDescription = SName[i];
                    ps.Add(srec);

                }
                catch
                {
                    break;
                }
            }
            foreach (var item in ps)
            {
                cc.ProjectStages.Add(item);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {

            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
           var rec= this.cc.Projects.Find(id);
           var rec1 = this.cc.ProjectStages.Where(p=>p.ProjectID==rec.ProjectID).ToList();
            //var srec= new ProjectStagesVM();
            //srec.ProjectName = rec.ProjectName;
            //srec.ProjectStagesID = rec1.ProjectStagesID;

            // srec.ProjectID = rec.ProjectID;

            ProjectVM pv = new ProjectVM();
            pv.ProjectName = rec.ProjectName;
            pv.ProjectID = rec.ProjectID;
            pv.NoOfStages=rec.ProjectStages.Count();
            foreach (var temp in rec1)
            {
                ProjectStageVM ps = new ProjectStageVM();
                ps.ProjectName = temp.Project.ProjectName;
                ps.ProjectStagesName = temp.ProjectStagesName;
                ps.DurationInHours= temp.DurationInHours;
                ps.StepsDescription= temp.StepsDescription;
                pv.ProjectStagesVMs.Add(ps);
                
            }
            return View(pv);
        }
        [HttpPost]
        public IActionResult Edit(ProjectStages rec, string[] SName, string[] PName, decimal[] DName)
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            var oldstage = this.cc.ProjectStages.Where(p => p.ProjectID == rec.ProjectID);
            foreach (var temp in oldstage)
            {
                this.cc.ProjectStages.Remove(temp);
            }
            List<ProjectStages> ps = new List<ProjectStages>();
            for (int i = 0; i < SName.Length; i++)
            {
                ProjectStages srec = new ProjectStages();
                try
                {
                    srec.ProjectID = rec.ProjectID;
                    srec.ProjectStagesName = PName[i];
                    srec.DurationInHours = DName[i];
                    srec.StepsDescription = SName[i];
                    ps.Add(srec);

                }
                catch
                {
                    break;
                }
            }
            foreach (var item in ps)
            {
                cc.ProjectStages.Add(item);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");             
            //    this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    this.cc.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var oldstage = this.cc.ProjectStages.Where(p => p.ProjectID == id);
            foreach (var temp in oldstage)
            {
                this.cc.ProjectStages.Remove(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
