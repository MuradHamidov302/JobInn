using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Blogs
{
    public class CommentReply
    {

        [Key]
        public int commentreply_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tam adınız")]
        public string user_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "E-mail ünvanı")]
        public string email { get; set; }
        [Column(TypeName = "ntext")]
        public string comment_text { get; set; }
        public int blogcomment_id { get; set; }
        
        [ForeignKey("blogcomment_id")]
        public virtual BlogComment blogcomment { get; set; }
    }
}