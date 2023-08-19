using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskQuerySolutionTbl")]
    public class ProjectTaskQuerySolution
    {
        [Key]
        public Int64 ProjectTaskQuerySolutionID { get; set; }
        public string SolutionTitle { get; set; }
        [ForeignKey("ProjectTaskQuery")]
        public Int64 ProjectTaskQueryID { get; set; }
        public string SolutionDescription { get; set; }
        public virtual ProjectTaskQuery ProjectTaskQuery { get; set; }
    }
}
