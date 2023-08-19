using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskReportConflictTbl")]
    public class ProjectTaskReportConflict
    {
        [Key]
        public Int64 ProjectTaskReportConflictID { get; set; }
        [ForeignKey("ProjectTaskReport")]
        public Int64 ProjectTaskReportID { get; set; }
        public DateTime ConflictDate { get; set; }
        public string ConflictRemark { get; set; }
        public virtual ProjectTaskReport ProjectTaskReport { get; set; }
        public virtual List<ProjectTaskReportConflictSolution> ProjectTaskReportConflictSolutions { get; set; }
    }
}
