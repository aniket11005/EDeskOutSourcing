using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("CompanyFAQTbl")]
    public class CompanyFAQ
    {
        [Key]
        public Int64 CompanyFAQID { get; set; }
        public string FAQ { get; set; }
        public string Answer { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
