using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskQueryTbl")]
    public class ProjectTaskQuery
    {
        [Key]
        public Int64 ProjectTaskQueryID { get; set; }
        public string QueryTitle { get; set; }
        [ForeignKey("ProjectTask")]
        public Int64 ProjectTaskID { get; set; }
        public string QueryDescription { get; set; }
        public bool IsSolved { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }
        public virtual List<ProjectTaskQuerySolution> ProjectTaskQuerySolutions { get; set; }
    }
}
