using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectApplicationTbl")]
    public class ProjectApplication
    {
        [Key]
        public Int64 ProjectApplicationID { get; set; }
        [ForeignKey("Freelancer")]
        public Int64 FreelancerID { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationTitle { get; set; }
        public virtual List<SelectedApplication> SelectedApplications { get; set; }
        public virtual Project Project { get; set; }
        public virtual Freelancer Freelancer { get; set; }
    }
}
