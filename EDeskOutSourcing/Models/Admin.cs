using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("AdminTbl")]
    public class Admin
    {
        [Key]
        public Int64 AdminID { get; set; }
        public string AdminName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
    }
}
