using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FreelancerExperienceTbl")]
    public class FreelancerExperience
    {
        [Key]
        public Int64 FreelancerExperienceID { get; set; }
        [ForeignKey("Freelancer")]
        public Int64 FreelancerID { get; set; }
        public int ExperienceInMonths { get; set; }
        public string RoleName { get; set; }
        public virtual Freelancer Freelancer { get; set; }
    }
}
