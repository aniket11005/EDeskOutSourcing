using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskTbl")]
    public class ProjectTask
    {
        [Key]
        public Int64 ProjectTaskID { get; set; }
        public string TaskTitle { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        public string TaskDescription { get; set; }
        public decimal TaskAmount { get; set; }
        public string TaskStatus { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<ProjectTaskDocument> ProjectTaskDocuments { get; set; }
        public virtual List<ProjectTaskAssignment> ProjectTaskAssignments { get; set; }
        public virtual List<ProjectTaskReport> ProjectTaskReports { get; set; }
        public virtual List<ProjectTaskQuery> ProjectTaskQueries { get; set; }
    }
}
