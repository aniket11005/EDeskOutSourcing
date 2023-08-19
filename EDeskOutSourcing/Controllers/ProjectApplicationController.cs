using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;

namespace EDeskOutSourcing.Controllers
{
    [FreelancerAuth]
    public class ProjectApplicationController : Controller
    {
        CompanyContext cc;
        public ProjectApplicationController(CompanyContext cntx)
        {
            cc = cntx;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Apply(Int64 id)
        {
            long FID = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            ProjectApplication pav = new ProjectApplication();
            pav.FreelancerID = FID;
            pav.ProjectID = id;
            return View(pav);
        }
        [HttpPost]
        public IActionResult Apply(ProjectApplication rec)
        {
            long FID = Convert.ToInt64(HttpContext.Session.GetString("FreelancerID"));
            cc.ProjectApplications.Add(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
