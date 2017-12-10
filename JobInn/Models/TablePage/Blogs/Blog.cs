﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Blogs
{
    public class Blog
    {
        [Key]
        public int blog_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "Bloq başlığı")]
        public string blog_title { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Bloq əsas mətn")]
        public string blog_maintext { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Bloq tanıtım mətni")]
        public string blog_alerttext { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Bloq kiçik başlıq")]
        [StringLength(100)]
        public string blog_smallhead { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Bloq kiçik mətin")]
        public string blog_smalltext { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Bloq şəkili")]
        public string blog_img { get; set; }
        [Column(TypeName = "Datetime")]
        [Display(Name = "Bloq elave olunma vaxtı")]
        public DateTime blog_datetime { get; set; }
        [Display(Name = "Şirkətin adı")]
        public int company_id { get; set; }

        [ForeignKey("company_id")]
        public virtual Company company { get; set; }
        public virtual ICollection<BlogComment> blogcomment { get; set; }
    }
}