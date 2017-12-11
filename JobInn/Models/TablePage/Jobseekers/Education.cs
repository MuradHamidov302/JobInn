using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Jobseekers
{
    public class Education
    {

        [Key]
        public int education_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "Ən son təhsil aldığınız yer")]
        public string school_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Başlama və bitmə vaxtı")]
        public string startent_date { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Əlavələriniz")]
        public string description { get; set; }
        public int jobseeker_id { get; set; }


        [ForeignKey("jobseeker_id")]
        public virtual Jobseeker jobseeker { get; set; }
    }
}