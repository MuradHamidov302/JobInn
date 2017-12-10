using JobInn.Models.TablePage.Jobseekers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Employers
{
    public class JobCategory
    {
        [Key]
        public int jobcategory_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        [Display(Name = "İş kateqoriya adı")]
        public string jobcategory_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Kateqoriya şəkili")]
        public string jobcategory_img { get; set; }

        public virtual ICollection<Job> job { get; set; }
        public virtual ICollection<Jobseeker> jobseeker { get; set; }
    }
}