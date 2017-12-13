using JobInn.Models.TablePage.Blogs;
using JobInn.Models.TablePage.Employers;
using JobInn.Models.TablePage.Jobseekers;
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
        public IEnumerable<JobType> jobtype { get; set; }
        public IEnumerable<Jobseeker> jobseeker { get; set; }
        public IEnumerable<Url> url { get; set; }
        public IEnumerable<Company> company { get; set; }
    }
}