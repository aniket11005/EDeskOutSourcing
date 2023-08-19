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
    public class ProjectTaskAssignmentController : Controller
    {
        CompanyContext cc;
        public ProjectTaskAssignmentController(CompanyContext Cntx)
        {
            this.cc = Cntx;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.ProjectTaskAssignments
                    join t1 in cc.ProjectTasks
                    on t.ProjectTaskID equals t1.ProjectTaskID
                    where t1.Project.CompanyID==cid
                    select t;
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TID = new SelectList(cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            ViewBag.FID = new SelectList(cc.Freelancers.ToList(), "FreelancerID", "FirstName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectTaskAssignment rec)
        {
            ViewBag.TID = new SelectList(cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            cc.ProjectTaskAssignments.Add(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.TID = new SelectList(cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            ViewBag.FID = new SelectList(cc.Freelancers.ToList(), "FreelancerID", "FirstName");
            var rec = cc.ProjectTaskAssignments.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(ProjectTaskAssignment rec)
        {
            ViewBag.TID = new SelectList(cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            ViewBag.FID = new SelectList(cc.Freelancers.ToList(), "FreelancerID", "FirstName");
            cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Int64 id)
        {
            var rec = cc.ProjectTaskAssignments.Find(id);
            cc.Remove(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
