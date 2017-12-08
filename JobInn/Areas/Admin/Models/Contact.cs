using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobInn.Areas.Admin.Models
{
    public class Contact
    {
        [Key]
        public int contact_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string comment { get; set; }

             
    }
}