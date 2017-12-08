using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Jobseekers
{
    public class Jobseeker
    {
        [Key]
        public int jobseekers_is { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string professional_title { get; set; }
        public string location_limk { get; set; }
        public string resume_category { get; set; }
        public string min_rate { get; set; }
        public string your_img { get; set; }
        public string description { get; set; }
        public string file { get; set; }
        public int url_id { get; set; }
        public int education_id { get; set; }
        public int experince_id { get; set; }
        public string user_id { get; set; }
    }
}