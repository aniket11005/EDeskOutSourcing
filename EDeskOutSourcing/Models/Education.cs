using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("EducationTbl")]
    public class Education
    {
        [Key]
        public Int64 EducationID { get; set; }
        public string EducationName { get; set; }
        public string EducationType { get; set; }
        public virtual List<FreelancerEducation>FreelancerEducations { get; set; }
    }
}
