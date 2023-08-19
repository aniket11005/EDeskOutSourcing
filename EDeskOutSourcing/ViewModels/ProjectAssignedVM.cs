using System;

namespace EDeskOutSourcing.ViewModels
{
    public class ProjectAssignedVM
    {
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public Int64 SelectedApplicationID { get; set; }
        public DateTime AssignDate { get; set; }
        public string Remark { get; set; }
        public Int64 FreelancerID { get; set; }
        public string FirstName { get; set; }
    }
}
