using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FreelancerPreviousProjectsTbl")]
    public class FreelancerPreviousProject
    {
        [Key]
        public Int64 FreelancerPreviousProjectsID { get; set; }
        [ForeignKey("Freelancer")]
        public Int64 FreelancerID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public virtual Freelancer Freelancer { get; set; }
    }
}
