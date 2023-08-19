using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class ProjectTaskQueryController: Controller
    {
        CompanyContext cc;
        public ProjectTaskQueryController(CompanyContext cntx)
        {
            cc = cntx;
        }
       
        public IActionResult Index()
        {
            var v = from t in cc.ProjectTaskQueries
                    join t1 in cc.ProjectTasks
                    on t.ProjectTaskID equals t1.ProjectTaskID
                    select t;
            //ViewBag.FID = new SelectList(v.ToList(), "FreelancerID", "FirstName");
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TID = new SelectList(this.cc.ProjectTasks.ToList(),"ProjectTaskID","TaskTitle");
            return View();
        }
        [HttpPost]
        public IActionResult Create( ProjectTaskQuery rec)
        {
            this.cc.ProjectTaskQueries.Add(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.TID = new SelectList(this.cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            var rec = this.cc.ProjectTaskQueries.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(ProjectTaskQuery rec)
        {
            ViewBag.TID = new SelectList(this.cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.ProjectTaskQueries.Find(id);
            this.cc.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
