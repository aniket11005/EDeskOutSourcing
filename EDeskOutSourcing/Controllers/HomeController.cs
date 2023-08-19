using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EDeskOutSourcing.Controllers
{
    public class HomeController : Controller
    {
        CompanyContext cc;
        public HomeController(CompanyContext cnc)
        {
            this.cc = cnc;
        }
        public IActionResult Index()
        {
            ViewBag.PID = new SelectList(this.cc.Projects.ToList(), "ProjectID", "ProjectName");
            var v = from t in cc.Projects
                    join t1 in cc.Companies on
                    t.CompanyID equals t1.CompanyID
                    
                    select new ProjectDetailsVM
                    {
                        ProjectID= t.ProjectID,
                        ProjectName= t.ProjectName,
                        CompanyName= t1.CompanyName,
                        Budget=t.Budget,

                    };
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var v = from t in cc.Projects
                    //join t1 in cc.Companies
                    //on t.CompanyID equals t1.CompanyID
                    //join t2 in cc.ProjectStages
                    //on t.ProjectID equals t2.ProjectID
                    where t.ProjectID== id
                    select new ProjectDetailsVM
                    {
                        ProjectID= t.ProjectID,
                        ProjectName = t.ProjectName,
                        CompanyName = t.Company.CompanyName,
                        ProjectDescription=t.ProjectDescription,
                        ProjectStatus=t.ProjectStatus,
                        ProjectPaymentTerms=t.ProjectPaymentTerms,
                        ProjectTermsAndConditions=t.ProjectTermsAndConditions,
                        Budget=t.Budget,
                    };
            return View(v.ToList());
        }
    }
}
