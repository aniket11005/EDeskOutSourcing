using System;
using System.ComponentModel.DataAnnotations;

namespace EDeskOutSourcing.ViewModels
{
    public class FreelancerVM
    { 
        [Required(ErrorMessage ="First Name Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile Number Required")]
        [RegularExpression(@"^\d{10}",ErrorMessage ="10 Digits Required")]
        public string MobileNo { get; set; }
        public Int64 ProjectApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationTitle { get; set; }
        public string EducationName { get; set; }
        public Int64 FreelancerID { get; set; }
        public string EmailID { get; set; }
        public Int64 FreelancerEducationID { get; set; }
        public Int64 EducationID { get; set; }
        public string PassingYear { get; set; }
        public string UniversityInstituteName { get; set; }
        public Int64 FreelancerCertificationsID { get; set; }
        public string CertificateTitle { get; set; }
        public Int64 FreelancerPreviousProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public Int64 FreelancerExprienceID { get; set; }
        public Int64 ExperienceInMonths { get; set; }
        public string RoleName { get; set; }
    }
}
