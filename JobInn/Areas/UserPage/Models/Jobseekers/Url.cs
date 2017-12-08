using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Jobseekers
{
    public class Url
    {
        [Key]
        public int url_id { get; set; }
        public string url_name { get; set; }
        public string url_link { get; set; }
    }
}