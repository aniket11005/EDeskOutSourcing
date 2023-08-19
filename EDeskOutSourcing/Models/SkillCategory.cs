using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDeskOutSourcing.Models
{
    [Table("SkillCategoryTbl")]
    public class SkillCategory
    {
        [Key]
        public Int64 SkillCategoryID { get; set; }
        public string SkillCategoryName { get; set; }
        public virtual List<Skill> Skills { get; set; }
    }
}
