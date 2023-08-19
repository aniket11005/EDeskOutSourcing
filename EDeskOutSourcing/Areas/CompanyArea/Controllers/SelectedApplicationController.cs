using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]

    public class SelectedApplicationController : Controller
    {
        CompanyContext cc;
        public SelectedApplicationController(CompanyContext cntc)
        {
            this.cc = cntc;
        }
        public IActionResult Index()
        {
            var v = from t in cc.SelectedApplications
                    where !(from t1 in cc.ProjectAssigneds
                            select t1.SelectedApplicationID
                           ).Contains(t.SelectedApplicationID)
                    select t;
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Selected(Int64 id)
        {
            ViewBag.PA = id;
            return View();
        }
        [HttpPost]
        public IActionResult Selected(SelectedApplication rec)
        {
            cc.SelectedApplications.Add(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
