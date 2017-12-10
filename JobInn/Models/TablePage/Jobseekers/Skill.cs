using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Jobseekers
{
    public class Skill
    {
        [Key]
        public int skill_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Bacarığınız")]
        public string skill_name { get; set; }
        [Range(0, 100)]
        [Display(Name = "Bilik dərəcəniz (0-100%)")]
        public int skill_degree { get; set; }
        public int jobseeker_id { get; set; }

        [ForeignKey("jobseeker_id")]
        public virtual Jobseeker jobseeker { get; set; }
    }
}