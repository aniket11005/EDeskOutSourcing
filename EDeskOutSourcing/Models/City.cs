using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("CityTbl")]
    public class City
    {
        [Key]
        public Int64 CityID { get; set; }
        public string CityName { get; set; }
        [ForeignKey("State")]
        public Int64 StateID { get; set; }
        public virtual State State { get; set; }
        public virtual List<Location> Locations { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}
