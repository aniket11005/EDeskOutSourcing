using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FinishedProjectTbl")]
    public class FinishedProject
    {
        [Key]
        public Int64 FinishedProjectID { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        public DateTime FinishedDate { get; set; }
        public string FinishedRemark { get; set; }
        public virtual Project Project { get; set; }
    }
}
