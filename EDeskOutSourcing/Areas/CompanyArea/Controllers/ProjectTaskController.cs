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
    public class ProjectTaskController : Controller
    {
        CompanyContext cc;
        public ProjectTaskController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.ProjectTasks
                    join t1 in cc.Projects
                    on t.ProjectID equals t1.ProjectID
                    where t1.CompanyID== cid
                    select t;
            return View(v.ToList()) ;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectTask rec)
        {
            cc.ProjectTasks.Add(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            var rec = this.cc.ProjectTasks.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(ProjectTask rec)
        {
            cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(Int64 id)
        {
            var rec = this.cc.ProjectTasks.Find(id);
            return View(rec);
        }
    }
}
