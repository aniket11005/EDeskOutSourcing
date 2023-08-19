using EDeskOutSourcing.CustFilters;
using EDeskOutSourcing.Models;
using EDeskOutSourcing.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace EDeskOutSourcing.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ProjectApplicationController : Controller
    {
        CompanyContext cc;
        public ProjectApplicationController(CompanyContext cntx) 
        {
         this.cc = cntx;
        }
        public IActionResult Index()
        {
            var u = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.ProjectApplications
                    join t1 in cc.Projects
                    on t.ProjectID equals t1.ProjectID
                    where  t.Project.CompanyID== u 
                    group t by t1.ProjectName into g


                    select new ProjectApplicationVM
                    { 
                        ProjectID=g.Max(p=>p.ProjectID),
                        ProjectList=g.Key,
                        NoOfForms= g.Count(),
                    };
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Details(Int64 id)
        {

            var v = from t in cc.ProjectApplications
                    //join t1 in cc.Projects
                    //on t.ProjectID equals t1.ProjectID
                    where t.ProjectID == id 
                    select t;
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult Profile(Int64 id)
        {

            FreelancerVM fvm= new FreelancerVM();
            var v =  cc.Freelancers.Find(id);

            fvm.FirstName = v.FirstName;
            fvm.LastName = v.LastName;
            fvm.Address= v.Address;
            fvm.EmailID= v.EmailID;
            fvm.MobileNo = v.MobileNo;

            var a= cc.ProjectApplications.Where(p=>p.FreelancerID==id).FirstOrDefault();

            fvm.ProjectApplicationID= a.ProjectApplicationID;
            fvm.ApplicationTitle= a.ApplicationTitle;
            fvm.ApplicationDate= a.ApplicationDate;

            var w= cc.FreelancerCertifications.Where(p=>p.FreelancerID== id).FirstOrDefault();



            fvm.CertificateTitle = w.CertificateTitle;
            fvm.PassingYear= w.PassingYear;
            fvm.UniversityInstituteName = w.UniversityInstituteName;
            
            var x=cc.FreelancerExperiences.Where(p => p.FreelancerID == id).FirstOrDefault();

            fvm.ExperienceInMonths= x.ExperienceInMonths;
            fvm.RoleName= x.RoleName;

            var y= cc.FreelancerPreviousProjects.Where(p => p.FreelancerID == id).FirstOrDefault();
            fvm.ProjectTitle= y.ProjectTitle;
            fvm.ProjectDescription= y.ProjectDescription;


                        ////join t1 in cc.ProjectApplications
                        ////on t.FreelancerID equals t1.FreelancerID
                        ////join t2 in cc.FreelancerCertifications
                        ////on t.FreelancerID equals t2.FreelancerID
                        ////join t3 in cc.FreelancerExperiences
                        ////on t.FreelancerID equals t3.FreelancerID
                        ////join t4 in cc.FreelancerPreviousProjects
                        ////on t.FreelancerID equals t4.FreelancerID
                        //where t.FreelancerID == id

                        //select new FreelancerVM
                        //{
                        //    FirstName = t.FirstName,
                        //    LastName = t.LastName,
                        //    Address = t.Address,
                        //    EmailID = t.EmailID,
                        //    MobileNo = t.MobileNo,
                        //    CertificateTitle=t2.CertificateTitle,
                        //    PassingYear = t2.PassingYear,
                        //    UniversityInstituteName = t2.UniversityInstituteName,
                        //    ExperienceInMonths =t3.ExperienceInMonths,
                        //    RoleName=t3.RoleName,
                        //    ProjectTitle=t4.ProjectTitle,
                        //    ProjectDescription=t4.ProjectDescription
                        //};

            return View(fvm);
        }

    }
}
