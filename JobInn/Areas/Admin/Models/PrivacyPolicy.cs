using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.Admin.Models
{
    public class PrivacyPolicy
    {
        [Key]
        public int pp_id { get; set; }
        public string pp_title {get;set;}
        public string pp_text { get; set; }
    }
}