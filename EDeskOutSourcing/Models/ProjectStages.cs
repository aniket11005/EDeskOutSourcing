using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectStagesTbl")]
    public class ProjectStages
    {
        [Key]
        public Int64 ProjectStagesID { get; set; }
        public string ProjectStagesName { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        public decimal DurationInHours { get; set; }
        public string StepsDescription { get; set; }
        public virtual Project Project { get; set; }
    }
    //public ProjectStages()
    //{
    //    ProjectStages[] p = new ProjectStages[5];
    //}
}
