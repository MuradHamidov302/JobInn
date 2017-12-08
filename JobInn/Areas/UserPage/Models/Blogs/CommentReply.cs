using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Blogs
{
    public class CommentReply
    {
        [Key]
        public int commentreply_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string comment_text { get; set; }
        public int blogComment_id { get; set; }
    }
}