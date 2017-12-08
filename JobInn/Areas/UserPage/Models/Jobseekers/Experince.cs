using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Jobseekers
{
    public class Experince
    {
        [Key]
        public int experince_id { get; set; }
        public string company_name { get; set; }
        public string startend_date { get; set; }
        public string description { get; set; }
    }
}