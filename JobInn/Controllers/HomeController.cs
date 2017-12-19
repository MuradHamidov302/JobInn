using JobInn.Models;
using JobInn.Models.TablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace JobInn.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        HomeViewModel vm = new HomeViewModel();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.city_id = new SelectList(db.city, "city_id", "city_name");
            ViewBag.jobcategory_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name");

            vm.city = db.city.ToList();
            vm.blog = db.blog.ToList();
            vm.job = db.job.ToList();
            vm.jobcategory = db.jobcategory.ToList();

            return View(vm);
        }
        public ActionResult JobPartial(int? Page)
        {
            var job = db.job.OrderBy(x=>x.clossing_date).ToList().ToPagedList(Page?? 1, 3);
            return View(job);
        }

        public ActionResult SearchList(string search=null, string citys=null,string jobcategory=null)
        {
            var Search = db.job.Where(j => j.job_title.Contains(search)).Where(c => c.city.city_name.Contains(citys)).Where(c => c.jobcategory.jobcategory_name.Contains(jobcategory)).ToList();
          
            return View(Search.OrderByDescending(item => item.clossing_date));
        }
    }
}