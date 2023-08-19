using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EDeskOutSourcing.ViewModels
{
    public class ProjectApplicationVM
    {
        public string ProjectList { get; set; }
        public Int64 NoOfForms { get; set; }
        public Int64 ProjectApplicationID { get; set; }
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }

    }
}
