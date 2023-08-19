using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("CountryTbl")]
    public class Country
    {
        [Key]
        public Int64 CountryID { get; set; }
        public string CountryName { get; set; }
        public virtual List<State> States { get; set; }
    }
}
