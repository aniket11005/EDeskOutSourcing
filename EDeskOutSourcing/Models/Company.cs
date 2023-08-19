using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("CompanyTbl")]
    public class Company
    {
        [Key]
        public Int64 CompanyID { get; set; }
        [Required(ErrorMessage ="Company Name Required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Address Required")]

        public string Address { get; set; }
        [Required(ErrorMessage = "EmailID  Required")]

        public string EmailID { get; set; }
        [Required(ErrorMessage = "MobileNo  Required")]

        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Contact Person Name Required")]

        public string ContactPersonName { get; set; }
        [ForeignKey("City")]
        [Required(ErrorMessage = "City Name  Required")]
        public Int64 CityID { get; set; }
        [Required(ErrorMessage = "Joined Date Required")]

        public DateTime JoinedDate { get; set; }
        public string Password { get; set; }
        public virtual City City { get; set; }
        public virtual List<Project>Projects { get; set; }
    }
}
