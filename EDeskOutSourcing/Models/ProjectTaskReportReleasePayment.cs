using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskReportReleasePaymentTbl")]
    public class ProjectTaskReportReleasePayment
    {
        [Key]
        public Int64 ProjectTaskReportReleasePaymentID { get; set; }
        [ForeignKey("ProjectTaskReport")]
        public Int64 ProjectTaskReportID { get; set; }
        public decimal PaymentAmount { get; set; }
        public virtual ProjectTaskReport ProjectTaskReport { get; set; }
    }
}
