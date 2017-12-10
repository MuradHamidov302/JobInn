using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage.Employers
{
    public class City
    {

        [Key]
        public int city_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(80)]
        [Display(Name = "Şirkətin adı")]
        public string city_name { get; set; }

        public virtual ICollection<Job> job { get; set; }
    }
}