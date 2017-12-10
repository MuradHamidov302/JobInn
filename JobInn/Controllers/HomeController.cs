using JobInn.Models;
using JobInn.Models.TablePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInn.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        HomeViewModel vm = new HomeViewModel();

        // GET: Home
        public ActionResult Index()
        {
            vm.city = db.city.ToList();
            vm.blog = db.blog.ToList();
            vm.job = db.job.ToList();
            vm.jobcategory = db.jobcategory.ToList();

            return View(vm);
        }
        
        
    }
}