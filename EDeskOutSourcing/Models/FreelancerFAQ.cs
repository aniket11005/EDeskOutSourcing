using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("FreelancerFAQTbl")]
    public class FreelancerFAQ
    {
        [Key]
        public Int64 FreelancerFAQID { get; set; }
        public string FAQ { get; set; }
        public string Answer { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
