using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskReportPaymentConflictSolutionTbl")]
    public class ProjectTaskReportPaymentConflictSolution
    {
        [Key]
        public Int64 ProjectTaskReportPaymentConflictSolutionID { get; set; }
        [ForeignKey("ProjectTaskReportPaymentConflict")]
        public Int64 ProjectTaskReportPaymentConflictID { get; set; }
        public DateTime SolutionDate { get; set; }
        public string SolutionDescription { get; set; }
        public virtual ProjectTaskReportReleasePaymentConflict ProjectTaskReportReleasePaymentConflict { get; set; }

    }
}
