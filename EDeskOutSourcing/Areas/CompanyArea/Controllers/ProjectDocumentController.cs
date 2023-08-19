using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ProjectDocumentController : Controller
    {
        CompanyContext cc;
        IWebHostEnvironment env;
        public ProjectDocumentController (CompanyContext csc,IWebHostEnvironment ienv)
        {
            this.cc = csc;
            this.env = ienv;
        }
        public IActionResult Index()
        {
            var v = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var rec = this.cc.ProjectDocuments.Where(p => p.Project.CompanyID == v).ToList();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PID=new SelectList(cc.Projects.ToList(),"ProjectID","ProjectName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectDocument rec)
        {
            ViewBag.PID = new SelectList(cc.Projects.ToList(), "ProjectID", "ProjectName");


            if (ModelState.IsValid)
            {
                if (rec.PhotoFile != null)
                {
                    if (rec.PhotoFile.Length > 0)
                    {
                        string Logicalpath = @"\Frontend\assets\img\ProjectDoc\" + rec.PhotoFile.FileName;
                        string Fullpath = env.WebRootPath + Logicalpath;
                        rec.PhotoFile.CopyTo(new FileStream(Fullpath, FileMode.Create));
                        rec.DocumentFilePath = Logicalpath;
                       
                    }
                    else
                    {
                        ModelState.AddModelError("PhotoFile", "Please Select File to upload!");
                        return View(rec);
                    }
                }
                else
                {
                    ModelState.AddModelError("PhotoFile", "Please Select File to upload!");
                    return View(rec);
                }
                this.cc.ProjectDocuments.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(rec);
        }
    
        [HttpGet]
        public IActionResult Edit(Int64 id)
        {
            ViewBag.PID = new SelectList(cc.Projects.ToList(), "ProjectID", "ProjectName");
            var rec=this.cc.ProjectDocuments.Find(id);
            return View(rec);  
        }
        [HttpPost]
        public IActionResult Edit(ProjectDocument rec)
        {
            ViewBag.PID = new SelectList(cc.Projects.ToList(), "ProjectID", "ProjectName");
            if (ModelState.IsValid)
            {
                if (rec.PhotoFile != null)
                {
                    if (rec.PhotoFile.Length > 0)
                    {
                        string Logicalpath = @"\Frontend\assets\img\ProjectDoc\" + rec.PhotoFile.FileName;
                        string Fullpath = env.WebRootPath + Logicalpath;
                        rec.PhotoFile.CopyTo(new FileStream(Fullpath, FileMode.Create));
                        rec.DocumentFilePath = Logicalpath;
                    }
                    else
                    {
                        ModelState.AddModelError("PhotoFile", "Please Select File to upload!");
                        return View(rec);
                    }
                }
                else
                {
                    ModelState.AddModelError("PhotoFile", "Please Select File to upload!");
                    return View(rec);
                }
                this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cc.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(rec);
        }
        public IActionResult Delete (Int64 id)
        {
           var rec= this.cc.ProjectDocuments.Find(id);
           this.cc.Remove(rec);
           this.cc.SaveChanges();
           return RedirectToAction("Index");
        }
    }
}
