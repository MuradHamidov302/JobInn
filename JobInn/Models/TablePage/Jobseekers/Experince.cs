using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Jobseekers
{
    public class Experince
    {
        [Key]
        public int experince_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        [Display(Name = "Ən son işlədiyiniz şirkətin adı")]
        public string company_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        [Display(Name = "Başlama və bitmə vaxtı")]
        public string startend_date { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Əlavələrniz")]
        public string description { get; set; }
        public int jobseeker_id { get; set; }


        [ForeignKey("jobseeker_id")]
        public virtual Jobseeker jobseeker { get; set; }
    }
}