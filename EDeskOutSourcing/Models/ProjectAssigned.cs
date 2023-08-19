using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectAssignedTbl")]
    public class ProjectAssigned
    {
        [Key]
        public Int64 ProjectAssignedID { get; set; }
        [ForeignKey("SelectedApplication")]
        public Int64 SelectedApplicationID { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        public DateTime AssignDate { get; set; }
        public string Remark { get; set; }
        public virtual Project Project { get; set; }
        public virtual SelectedApplication SelectedApplication { get; set; }
    }
}
