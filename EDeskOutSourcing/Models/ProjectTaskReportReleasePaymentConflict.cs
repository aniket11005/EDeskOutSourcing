using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskReportReleasePaymentConflictTbl")]
    public class ProjectTaskReportReleasePaymentConflict
    {
        [Key]
        public Int64 ProjectTaskReportReleasePaymentConflictID { get; set; }
        [ForeignKey("ProjectTaskReport")]
        public Int64 ProjectTaskReportID { get; set; }
        public decimal PaymentAmount { get; set; }
        public virtual ProjectTaskReport ProjectTaskReport { get; set; }
        public virtual List<ProjectTaskReportPaymentConflictSolution> ProjectTaskReportPaymentConflictSolutions { get; set; }

    }
}
