using System;
using System.Collections.Generic;

namespace EDeskOutSourcing.ViewModels
{
    public class ProjectVM
    {
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public Int64 NoOfStages { get; set; }

        public List<ProjectStageVM> ProjectStagesVMs { get; set; }
        public ProjectVM()
        {
            ProjectStagesVMs = new List<ProjectStageVM>();
        }

    }

    public class ProjectStageVM
    {
        public Int64 ProjectStagesID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStagesName { get; set; }
        public string StepsDescription { get; set; }
        public decimal DurationInHours { get; set; }
        //public Int64 NoOfStages { get; set; }

    }

}
