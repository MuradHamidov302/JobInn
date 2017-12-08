using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Jobseekers
{
    public class Skill
    {
        [Key]
        public int skill_id { get; set; }
        public string skill_name { get; set; }
        public int skill_degree { get; set; }
        public int jobseekers { get; set; }
    }
}