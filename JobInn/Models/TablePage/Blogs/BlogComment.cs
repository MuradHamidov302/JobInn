using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Blogs
{
    public class BlogComment
    {


        [Key]
        public int blogcomment_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tam adınız")]
        public string user_name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "E-mail ünvanı")]
        public string email { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Şərhiniz")]
        public string comment_text { get; set; }
        public int blog_id { get; set; }

        [ForeignKey("blog_id")]
        public virtual Blog blog { get; set; }
        public virtual ICollection<CommentReply> commentreply { get; set; }

    }
}