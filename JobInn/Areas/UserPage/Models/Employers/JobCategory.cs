using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.UserPage.Models.Employers
{
    public class JobCategory
    {
        [Key]
        public int jobcategory_id { get; set; }
        public string jobcategory_name { get; set; }
        public string jobcategory_img { get; set; }
    }
}