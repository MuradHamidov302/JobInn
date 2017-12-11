using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Employers
{
    public class JobTypeColor
    {
        [Key]
        public int typecolor_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        [Display(Name = "rəng adı")]
        public string color_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        [Display(Name = "Reng class adı")]
        public string color_class { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        [Display(Name = "Detail Reng class adı")]
        public string colorDetail_class { get; set; }


        public virtual ICollection<JobType> jobtype { get; set; }
    }
}