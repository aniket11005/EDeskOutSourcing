using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    public class Location
    {
        [Key]
        public Int64 LocationID { get; set; }
        public string LocationName { get; set; }
        [ForeignKey("City")]
        public Int64 CityID { get; set; }
        public virtual City City { get; set; }
    }
}
