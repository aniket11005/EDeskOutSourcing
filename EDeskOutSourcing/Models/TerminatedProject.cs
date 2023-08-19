using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("TerminatedProjectTbl")]
    public class TerminatedProject
    {
        [Key]
        public Int64 TerminatedProjectID { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        public DateTime TerminationDate { get; set; }
        public string TerminationRemark { get; set; }
        public virtual Project Project { get; set; }
    }
}
