using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ProjectAssignedController : Controller
    {
        CompanyContext cc;
        public ProjectAssignedController(CompanyContext cntx)
        {
            cc = cntx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Assigned()
        {
            var v = from t in cc.ProjectAssigneds
                    join t1 in cc.SelectedApplications
                    on t.SelectedApplicationID equals t1.SelectedApplicationID
                    join t2 in cc.ProjectApplications
                    on t1.ProjectApplicationID equals t2.ProjectApplicationID
                    
                    select new ProjectAssignedVM
                    {
                        SelectedApplicationID = t.SelectedApplicationID,
                        ProjectID = t.ProjectID,
                        ProjectName = t.Project.ProjectName,
                        FirstName=t2.Freelancer.FirstName,
                        AssignDate = t.AssignDate,
                        Remark = t.Remark,
                        FreelancerID=t2.FreelancerID,
                    };
            ViewBag.FID = new SelectList(v.ToList(), "FreelancerID", "FirstName");
            //ViewBag.Id = v.Max(p => p.FreelancerID);
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Assign(Int64 id,Int64 data)
        {
               
            ViewBag.SID = id;
            //var v = cc.SelectedApplications.Find(data);
            var rec = (from t in cc.ProjectApplications where t.ProjectApplicationID==data select t).SingleOrDefault();
            ViewBag.PID = rec.ProjectID;
            //ViewBag.PID=new SelectList(this.cc.Projects.ToList(),"ProjectID","ProjectName");
            //ViewBag.SID = new SelectList(this.cc.SelectedApplications.ToList(), "SelectedApplicationID", "Selection Date");
            return View();
        }
        [HttpPost]
        public IActionResult Assign(ProjectAssigned rec)
        {
            cc.ProjectAssigneds.Add(rec);
            cc.SaveChanges();
            return RedirectToAction("Index","CompanyHome", new {area="CompanyArea"});
        }
        
        public IActionResult NotAssigned()
        {
            var v = from t in cc.SelectedApplications
                    where !(from t1 in cc.ProjectAssigneds
                            select t1.SelectedApplicationID
                           ).Contains(t.SelectedApplicationID)
                    select t;
                    //on t.ProjectApplicationID equals t1.ProjectApplicationID
                    //where t1.FreelancerID == FID && !(from t2 in cc.ProjectAssigneds
                    //                                join t3 in cc.SelectedApplications
                    //                                on t2.SelectedApplicationID equals t3.ProjectApplicationID
                    //                                where t3.ProjectApplication.FreelancerID==FID
                    //                          select t2.SelectedApplicationID).Contains(t.SelectedApplicationID)
                    //select t;
            return View(v.ToList());
        }
    }
}
