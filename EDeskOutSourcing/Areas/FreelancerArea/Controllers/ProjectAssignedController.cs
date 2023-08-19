using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.FreelancerArea.Controllers
{
    [Area("FreelancerArea")]
    [FreelancerAuth]
    public class ProjectAssignedController : Controller
    {
        CompanyContext cc;
        public ProjectAssignedController(CompanyContext cntx)
        {
            cc = cntx;
        }
       
        public IActionResult Index()
        {
            Int64 fid = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            var v = from t in cc.ProjectAssigneds
                    join t1 in cc.SelectedApplications
                    on t.SelectedApplicationID equals t1.SelectedApplicationID
                    join t2 in cc.ProjectApplications
                    on t1.ProjectApplicationID equals t2.ProjectApplicationID
                    where t1.ProjectApplication.FreelancerID==fid
                    select new ProjectAssignedVM
                    {
                        SelectedApplicationID = t.SelectedApplicationID,
                        ProjectID = t.ProjectID,
                        ProjectName=t.Project.ProjectName,
                        AssignDate = t.AssignDate,
                        Remark = t.Remark,
                        
                    };
            ViewBag.FID = new SelectList(v.ToList(), "FreelancerID", "FirstName");
            //ViewBag.Id = v.Max(p => p.FreelancerID);
            return View(v.ToList());
        }

       
    }
}
