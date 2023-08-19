using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FreelancerCertificationsTbl")]
    public class FreelancerCertifications
    {
        [Key]
        public Int64 FreelancerCertificationsID { get; set; }
        [ForeignKey("Freelancer")]
        public Int64 FreelancerID { get; set; }
        public string CertificateTitle { get; set; }
        public string PassingYear { get; set; }
        public string UniversityInstituteName { get; set; }
        public virtual Freelancer Freelancer { get; set; }
    }
}
