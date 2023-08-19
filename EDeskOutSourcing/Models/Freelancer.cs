using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FreelancerTbl")]
    public class Freelancer
    {
        [Key]
        public Int64 FreelancerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public virtual List<FreelancerExperience> FreelancerExperiences { get; set; }
        public virtual List<FreelancerEducation> FreelancerEducations { get; set; }
        public virtual List<FreelancerPreviousProject> FreelancerPreviousProjects { get; set; }
        public virtual List<FreelancerCertifications> FreelancerCertifications { get; set; }
        public virtual List<ProjectApplication> ProjectApplications { get; set; }
        public virtual List<ProjectTaskAssignment> ProjectTaskAssignments { get; set; }
    }
}
