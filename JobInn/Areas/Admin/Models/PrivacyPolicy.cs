using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Areas.Admin.Models
{
    public class PrivacyPolicy
    {
        [Key]
        public int pp_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Başlıq")]
        public string pp_title {get;set;}
        [Column(TypeName = "ntext")]
        [Display(Name = "Mətn")]
        public string pp_text { get; set; }
    }
}