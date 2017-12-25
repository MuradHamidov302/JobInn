using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInn.Models.TablePage.Blogs
{
    public class Blog
    {
        [Key]
        public int blog_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string blog_title { get; set; }
        [Column(TypeName = "ntext")]
        [UIHint("tinymce_full_compressed"),AllowHtml]
        public string blog_maintext { get; set; }
        [Column(TypeName = "nvarchar")]
        public string blog_alerttext { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string blog_smallhead { get; set; }
        [Column(TypeName = "ntext")]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string blog_smalltext { get; set; }
        [Column(TypeName = "nvarchar")]
        public string blog_img { get; set; }
        [Column(TypeName = "Datetime")]
        public DateTime blog_datetime { get; set; }
        public int company_id { get; set; }

        [ForeignKey("company_id")]
        public virtual Company company { get; set; }
        public virtual ICollection<BlogComment> blogcomment { get; set; }
    }
}