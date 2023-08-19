using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("SkillTbl")]
    public class Skill
    {
        [Key]
        public Int64 SkillID { get; set; }
        public string SkillName { get; set; }
        [ForeignKey("SkillCategory")]
        public Int64 SkillCategoryID { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }
    }
}
