using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FreelancerEducationTbl")]
    public class FreelancerEducation
    {
        [Key]
        public Int64 FreelancerEducationID { get; set; }
        [ForeignKey("Freelancer")]
        public Int64 FreelancerID { get; set; }
        [ForeignKey("Education")]
        public Int64 EducationID { get; set; }
        public string PassingYear { get; set; }
        public string UniversityInstituteName { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual Education Education { get; set; }
    }
}
