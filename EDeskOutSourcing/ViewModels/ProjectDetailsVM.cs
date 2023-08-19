using System.ComponentModel.DataAnnotations.Schema;
using System;
using EDeskOutSourcing.Models;

namespace EDeskOutSourcing.ViewModels
{
    public class ProjectDetailsVM
    {
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public Int64 CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectPaymentTerms { get; set; }
        public string ProjectTermsAndConditions { get; set; }
        public decimal Budget { get; set; }
        public decimal ExpectedCompletionDurationDays { get; set; }
        public Int64 ProjectStagesID { get; set; }
        public string ProjectStagesName { get; set; }
        public decimal DurationInHours { get; set; }
        public string StepsDescription { get; set; }
       

    }
}
