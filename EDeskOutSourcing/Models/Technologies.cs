using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("TechnologyTbl")]
    public class Technologies
    {
        [Key]
        public Int64 TechnologyID { get; set; }
        public string TechnologyName { get; set; }
    }
}
