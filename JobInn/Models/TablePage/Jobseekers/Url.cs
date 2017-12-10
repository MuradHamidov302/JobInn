using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Jobseekers
{
    public class Url
    {
        [Key]
        public int url_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Link adı")]
        public string url_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Əlaqə linki")]
        public string url_link { get; set; }


        public virtual ICollection<Jobseeker> jobseeker { get; set; }
    }
}