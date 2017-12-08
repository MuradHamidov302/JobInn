using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Blogs
{
    public class Blog
    {
        [Key]
        public int blog_id { get; set; }
        public string blog_title { get; set; }
        public string blog_maintext { get; set; }
        public string blog_alerttext { get; set; }
        public string blog_smallhead { get; set; }
        public string blog_smalltext { get; set; }
        public string blog_img { get; set; }
        public DateTime blog_datetime { get; set; }
        public int company_id { get; set; }
       
    }
}