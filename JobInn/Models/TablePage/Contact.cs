using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage
{
    public class Contact
    {
        [Key]
        public int contact_id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "Tam adıniz")]
        public string name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "E-mail ünvanı")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Başlıq")]
        public string subject { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Mətn")]
        public string comment { get; set; }
    }
}