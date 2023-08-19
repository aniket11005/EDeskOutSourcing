using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskAssignmentTbl")]
    public class ProjectTaskAssignment
    {
        [Key]
        public Int64 ProjectTaskAssignmentID { get; set; }
        [ForeignKey("ProjectTask")]
        public Int64 ProjectTaskID { get; set; }
        [ForeignKey("Freelancer")]
        public Int64 FreelancerID { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }
        public virtual List<ProjectTaskReport> ProjectTaskReports { get; set; }
    }
}
