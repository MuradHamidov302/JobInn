using JobInn.Models.TablePage.Jobseekers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage
{
    public class JobseekersViewModel
    {
        public string full_name { get; set; }
        public string email { get; set; }
        public string professional_title { get; set; }
        public int category_id { get; set; }
        public string min_rate { get; set; }
        public string your_img { get; set; }
        [Column(TypeName = "ntext")]
        public string description1 { get; set; }
        public string file { get; set; }
        public string user_id { get; set; }
        public string location { get; set; }
        public int jobtype_id { get; set; }

    


        public string school_name { get; set; }
        public string startent_date { get; set; }
        public string description2 { get; set; }


        public string company_name { get; set; }
        public string startend_date { get; set; }
        public string description3 { get; set; }
       



        public string skill_name { get; set; }
        public int skill_degree { get; set; }


        public string url_name { get; set; }
        public string url_link { get; set; }

    }
}