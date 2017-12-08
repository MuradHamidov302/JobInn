using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Blogs
{
    public class BlogComment
    {
        [Key]
        public int blogcomment_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string comment_text { get; set; }
        public int blog_id { get; set; }

    }
}