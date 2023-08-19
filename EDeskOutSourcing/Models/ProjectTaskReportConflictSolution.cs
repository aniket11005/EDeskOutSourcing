using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskReportConflictSolutionTbl")]
    public class ProjectTaskReportConflictSolution
    {
        [Key]
        public Int64 ProjectTaskReportConflictSolutionID { get; set; }
        [ForeignKey("ProjectTaskReportConflict")]
        public Int64 ProjectTaskReportConflictID { get; set; }
        public DateTime SolutionDate { get; set; }
        public string SolutionDescription { get; set; }
        public virtual ProjectTaskReportConflict ProjectTaskReportConflict { get; set; }
    }
}
