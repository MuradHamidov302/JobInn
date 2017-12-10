using JobInn.Models.TablePage.Blogs;
using JobInn.Models.TablePage.Employers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobInn.Models.TablePage
{
    public class HomeViewModel
    {
        public IEnumerable<City> city { get; set; }
        public IEnumerable<JobCategory> jobcategory { get; set; }
        public IEnumerable<Job> job { get; set; }
        public IEnumerable<Blog> blog { get; set; }
    }
}