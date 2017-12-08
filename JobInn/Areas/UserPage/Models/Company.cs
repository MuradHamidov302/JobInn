using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models
{
    public class Company
    {
        [Key]
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string tagline { get; set; }
        public string description { get; set; }
        public string video_link { get; set; }
        public string web_site { get; set; }
        public string facebook_link { get; set; }
        public string googleplus_link { get; set; }
        public string twitter_link { get; set; }
        public string linkedin_link { get; set; }
        public string youtube_link { get; set; }
        public string logo_img { get; set; }
        public string user_id { get; set; }
    }
}