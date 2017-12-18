using JobInn.Models.TablePage.Blogs;
using JobInn.Models.TablePage.Employers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInn.Models.TablePage
{
    public class Company
    {

        [Key]
        public int company_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        [Display(Name = "Şirkətin adı")]
        public string company_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Şirkət haqqında kiçik başliq")]
        public string tagline { get; set; }
        [Column(TypeName = "ntext")]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string description { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Video link")]
        public string video_link { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "web sayt link")]
        public string web_site { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Facebook link")]
        public string facebook_link { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Google+ link")]
        public string googleplus_link { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Twitter link")]
        public string twitter_link { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Linkedin link")]
        public string linkedin_link { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "YouTube link")]
        public string youtube_link { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Şirkətin logosu")]
        public string logo_img { get; set; }
        public string user_id { get; set; }



        [ForeignKey("user_id")]
        public virtual ApplicationUser user { get; set; }
        public virtual ICollection<Blog> blog { get; set; }
        public virtual ICollection<Job> job { get; set; }
    }
}