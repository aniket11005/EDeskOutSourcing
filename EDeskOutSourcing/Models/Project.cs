using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTbl")]
    public class Project
    {
        [Key]
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        [ForeignKey("Company")]
        public Int64 CompanyID { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectPaymentTerms { get; set; }
        public string ProjectTermsAndConditions { get; set; }
        public decimal Budget { get; set; }
        public decimal ExpectedCompletionDurationDays { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<ProjectStages> ProjectStages { get; set; }
        public virtual List<TerminatedProject> TerminatedProjects { get; set; }
        public virtual List<FinishedProject> FinishedProjects { get; set; }
        public virtual List<ProjectDocument> ProjectDocuments { get; set; }
        public virtual List<ProjectApplication> ProjectApplications { get; set; }
        public virtual List<ProjectAssigned> ProjectAssigneds { get; set; }
        public virtual List<ProjectTask> ProjectTasks { get; set; }
      
    }
}
