using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("ProjectDocumentTbl")]
    public class ProjectDocument
    {
        [Key]
        public Int64 ProjectDocumentID { get; set; }
        public string DocumentName { get; set; }
        [ForeignKey("Project")]
        public Int64 ProjectID { get; set; }
        
        public string DocumentFilePath { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
        public virtual Project Project { get; set; }
    }
}
