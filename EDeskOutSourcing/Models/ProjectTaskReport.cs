using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskReportTbl")]
    public class ProjectTaskReport
    {
        [Key]
        public Int64 ProjectTaskReportID { get; set; }
        [ForeignKey("ProjectTaskAssignment")]
        public Int64 ProjectTaskAssignmentID { get; set; }
        [ForeignKey("ProjectTaskDocument")]
        public Int64 ProjectTaskID { get; set; }
        [NotMapped]
        public string SourceFilePath { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }

        public bool IsReviewed { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }
        public virtual ProjectTaskAssignment ProjectTaskAssignment { get; set; }
        public virtual List<ProjectTaskReportConflict> ProjectTaskReportConflicts { get; set; }
        public virtual List<ProjectTaskReportReleasePayment> ProjectTaskReportReleasePayments { get; set; }
        public virtual List<ProjectTaskReportReleasePaymentConflict> ProjectTaskReportReleasePaymentConflicts { get; set; }
    }
}
