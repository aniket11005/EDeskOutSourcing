using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ProjectTaskDocumentController : Controller
    {
        CompanyContext cc;
        IWebHostEnvironment env;
        public ProjectTaskDocumentController(CompanyContext cntx,IWebHostEnvironment ienv)
        {
            this.cc = cntx;
            this.env = ienv;
        }
        public IActionResult Index()
        {
            Int64 cid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var rec = from t in cc.ProjectTaskDocuments
                      join t1 in cc.ProjectTasks
                      on t.ProjectTaskID equals t1.ProjectTaskID
                      where t1.Project.CompanyID==cid
                      select t;
            return View(rec.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TID=new SelectList(cc.ProjectTasks.ToList(),"ProjectTaskID","TaskTitle");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectTaskDocument rec)
        {
            ViewBag.TID = new SelectList(cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");

            if (ModelState.IsValid)
            {
                if (rec.PhotoFile != null)
                {
                    if (rec.PhotoFile.Length > 0)
                    {
                        string Logicalpath = @"\Frontend\assets\img\ProjectDoc\" + rec.PhotoFile.FileName;
                        string Fullpath=env.WebRootPath + Logicalpath;
                        rec.PhotoFile.CopyTo(new FileStream(Fullpath,FileMode.Create));
                        rec.ProjectDocumentFilePath = Logicalpath;
                        //string filename = rec.PhotoFile.FileName;
                        //string UploadPath = Path.Combine(this.env.WebRootPath, "ProjectDoc");
                        //UploadPath = Path.Combine(UploadPath, filename);
                        //rec.PhotoFile.CopyTo(new FileStream(UploadPath, FileMode.Create));
                        //rec.ProjectDocumentFilePath = @"\ProjectDoc\" + filename;
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
                this.cc.ProjectTaskDocuments.Add(rec);
                this.cc.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(rec);
           
        }
        [HttpGet]
        public IActionResult Edit(Int64 id, Int64 data)
        {
            ViewBag.TID = data;
            var rec = this.cc.ProjectTaskDocuments.Find(id);
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(ProjectTaskDocument rec)
        {
            //ViewBag.TID = new SelectList(cc.ProjectTasks.ToList(), "ProjectTaskID", "TaskTitle");
            if (ModelState.IsValid)
            {
                if (rec.PhotoFile != null)
                {
                    if (rec.PhotoFile.Length > 0)
                    {
                        string Logicalpath = @"\Frontend\assets\img\ProjectDoc\" + rec.PhotoFile.FileName;
                        string Fullpath = env.WebRootPath + Logicalpath;
                        rec.PhotoFile.CopyTo(new FileStream(Fullpath, FileMode.Create));
                        rec.ProjectDocumentFilePath = Logicalpath;
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
        public IActionResult Delete(Int64 id)
        {
            var rec = this.cc.ProjectTaskDocuments.Find(id);
            cc.Remove(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
