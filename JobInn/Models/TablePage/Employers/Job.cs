using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInn.Models.TablePage.Employers
{
    public class Job
    {

        [Key]
        public int job_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Əlaqli şəxsin tam adı")]
        public string concerperson_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "E-mail ünvanı")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "İş haqqında başlıq")]
        public string job_title { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Ünvan")]
        public string location { get; set; }
        [Display(Name = "Şəhər")]
        public int city_id { get; set; }
        [Display(Name = "Kateqoriya")]
        public int jobcategory_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Maaş haqqında(max-min məbləğ)")]
        public string salary_package { get; set; }
        [Display(Name = "İş müddəti")]
        public int jobtype_id { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Elanın bitmə vaxtı")]
        public DateTime clossing_date { get; set; }
        [Display(Name = "Şirkətin adı")]
        public int? company_id { get; set; }
        public string user_id { get; set; }
        [Column(TypeName = "ntext")]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string description { get; set; }

        [ForeignKey("city_id")]
        public virtual City city { get; set; }
        [ForeignKey("jobcategory_id")]
        public virtual JobCategory jobcategory { get; set; }
        [ForeignKey("jobtype_id")]
        public virtual JobType jobtype { get; set; }
        [ForeignKey("company_id")]
        public virtual Company company { get; set; }
        [ForeignKey("user_id")]
        public virtual ApplicationUser user { get; set; }
    }
}