using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("SelectedApplicationTbl")]
    public class SelectedApplication
    {
        [Key]
        public Int64 SelectedApplicationID { get; set; }
        [ForeignKey("ProjectApplication")]
        public Int64 ProjectApplicationID { get; set; }
        public DateTime SelectionDate { get; set; }
        public DateTime NeedStartDate { get; set; }
        public string AnyRemark { get; set; }
        public virtual List<ProjectAssigned> ProjectAssigneds { get; set; }
        public virtual ProjectApplication ProjectApplication { get; set; }

    }
}
