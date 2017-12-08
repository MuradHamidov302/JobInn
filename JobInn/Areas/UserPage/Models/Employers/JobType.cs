using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Employers
{
    public class JobType
    {
        [Key]
        public int jobtype_id { get; set; }
        public string jobtype_name { get; set; }
    }
}