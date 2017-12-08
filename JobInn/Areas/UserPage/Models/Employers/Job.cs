using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Employers
{
    public class Job
    {
        [Key]
        public int job_id { get; set; }
        public string concerperson_name { get; set; }
        public string email { get; set; }
        public string job_title { get; set; }
        public string location { get; set; }
        public int country_id { get; set; }
        public int jobcategory_id {get;set;}
        public string salary_package { get; set; }
        public int jobtype_id { get; set; }
        public DateTime clossing_date { get; set; }
        public int company_id { get; set; }
        public string user_id { get; set; }
    }
}