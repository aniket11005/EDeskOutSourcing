using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("TermsAndConditonForCompanyTbl")]
    public class TermsAndConditionForCompany
    {
        [Key]
        public Int64 TermsAndConditionRuleID { get; set; }
        public string CompanyRule { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
