using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Employers
{
    public class JobType
    {
        [Key]
        public int jobtype_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        [Display(Name = "İş müddeti növü")]
        public string jobtype_name { get; set; }
        [Display(Name = "Növ rəngi")]
        public int jobcolor_id { get; set; }

        [ForeignKey("jobcolor_id")]
        public virtual JobTypeColor jobtypecolor { get; set; }
        public virtual ICollection<Job> job { get; set; }
    }
}