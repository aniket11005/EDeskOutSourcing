using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class PaymentModeController : Controller
    {
        CompanyContext cc;
        public PaymentModeController(CompanyContext cntx)
        {
            this.cc = cntx;
        }
        public IActionResult Index()
        {
            return View(this.cc.PaymentModes.ToList());
        }
        [HttpGet]
        public IActionResult Create(int mode)
        {
            ViewBag.PaymentMode = mode;
            return View();
        }
        [HttpPost]
        public IActionResult Create(PaymentMode rec)
        {
            if(ModelState.IsValid)
            {
                this.cc.PaymentModes.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index", "PaymentMode", new {area="AdminArea"});
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            var rec = this.cc.PaymentModes.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(PaymentMode rec)
        {
            if(ModelState.IsValid)
            {
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index", "PaymentMode", new { area = "AdminArea" });
            }
            return View(rec);
        }
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.PaymentModes.Find(id);
            this.cc.PaymentModes.Remove(rec);
            this.cc.SaveChanges();
            return View("Index");
        }
    }
}
