using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Jobseekers
{
    public class Education
    {
        [Key]
        public int education_id { get; set; }
        public string school_name { get; set; }
        public string startent_date { get; set; }
        public string description { get; set; }

    }
}