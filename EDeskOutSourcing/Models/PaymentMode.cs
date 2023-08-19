using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("PaymentModeTbl")]
    public class PaymentMode
    {
        [Key]
        public Int64 PaymentModeID { get; set; }
        public string PaymentModeName { get; set; }
    }
}
