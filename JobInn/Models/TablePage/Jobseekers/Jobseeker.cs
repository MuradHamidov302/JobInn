using JobInn.Models.TablePage.Employers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInn.Models.TablePage.Jobseekers
{
    public class Jobseeker
    {
        [Key]
        public int jobseekers_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tam adınız")]
        public string full_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "E-mail ünvanı")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "İxtisasınız")]
        public string professional_title { get; set; }
        [Display(Name = "Kateqoriya")]
        public int category_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        [Display(Name = "Minium maaş miqdarı")]
        public string min_rate { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Sizin şəkliniz")]
        public string your_img { get; set; }
        [Column(TypeName = "ntext")]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string description { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Sənəd əlavə edin(Cv-form, Sertifikat vı.s)")]
        public string file { get; set; }
        //[Display(Name = "Əlaqə linki")]
        //public int url_id { get; set; }
        //[Display(Name = "Son Təhsil yeri")]
        //public int education_id { get; set; }
        //[Display(Name = "Son iş yeri")]
        //public int experince_id { get; set; }
        public string user_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string location { get; set; }
        public int jobtype_id { get; set; }



        public virtual ICollection<Skill> skill { get; set; }

        [ForeignKey("jobtype_id")]
        public virtual JobType jobtype { get; set; }
        [ForeignKey("category_id")]
        public virtual JobCategory jobcategory { get; set; }
       
        public virtual ICollection<Url> url { get; set; }
      
        public virtual ICollection<Education> education { get; set; }
       
        public virtual ICollection<Experince> experince { get; set; }
        [ForeignKey("user_id")]
        public virtual ApplicationUser user { get; set; }
    }
}