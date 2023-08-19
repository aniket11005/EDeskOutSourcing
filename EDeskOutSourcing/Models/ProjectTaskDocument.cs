using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectTaskDocumentTbl")]
    public class ProjectTaskDocument
    {
        [Key]
        public Int64 ProjectTaskDocumentID { get; set; }
        [ForeignKey("ProjectTask")]
        public Int64 ProjectTaskID { get; set; }
        
        public string ProjectDocumentFilePath { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }

        public virtual ProjectTask ProjectTask { get; set; }
    }
}
