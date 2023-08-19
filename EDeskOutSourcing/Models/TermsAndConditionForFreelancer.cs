using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("TermsAndConditonForFreelancerTbl")]
    public class TermsAndConditionForFreelancer
    {
        [Key]
        public Int64 TermsAndConditionRuleID { get; set; }
        public string FreelancerRule { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
