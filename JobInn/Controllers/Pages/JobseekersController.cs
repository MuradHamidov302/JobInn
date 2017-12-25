using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobInn.Models;
using JobInn.Models.TablePage.Jobseekers;
using JobInn.Models.TablePage;
using System.IO;

namespace JobInn.Controllers.Pages
{
    [Authorize]
    public class JobseekersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        HomeViewModel vm = new HomeViewModel();
        [AllowAnonymous]
        // GET: Jobseekers
        public ActionResult Index()
        {
            vm.url = db.url.ToList();
            vm.jobseeker = db.jobseeker.ToList();
            vm.jobcategory = db.jobcategory.ToList();
            vm.jobtype = db.jobtype.ToList();
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult JobseekerList(string Search = null)
        {
            var search = db.jobseeker.Where(j => j.professional_title.Contains(Search)).ToList();

            return View(search);
        }



        [AllowAnonymous]
        // GET: Jobseekers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobseeker jobseeker = db.jobseeker.Find(id);
            if (jobseeker == null)
            {
                return HttpNotFound();
            }
            return View(jobseeker);
        }


       
        // GET: Jobseekers/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name");
            ViewBag.jobtype_id = new SelectList(db.jobtype, "jobtype_id", "jobtype_name");
          
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name");
            return View();
        }
       
        // POST: Jobseekers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobseekersViewModel viewModel, HttpPostedFileBase profilimg,HttpPostedFileBase resumeimg)
        {

           if (ModelState.IsValid)
            {

             var jobseekers1 = new Jobseeker()
             {
                full_name = viewModel.full_name,
                email = viewModel.email,
                professional_title=viewModel.professional_title,
                category_id=viewModel.category_id,
                min_rate=viewModel.min_rate,
                description =viewModel.description1,
                user_id= Convert.ToString(Session["UserId"]),
                location=viewModel.location,
                jobtype_id=viewModel.jobtype_id
            };
                if (profilimg != null)
                {
                    var filename = profilimg.FileName;
                    string ext = Path.GetExtension(profilimg.FileName);

                    string FileYolu = Guid.NewGuid().ToString() + filename;
                    var yuklemeYeri = Server.MapPath("/Content/images/profile/") + FileYolu;
                    profilimg.SaveAs(yuklemeYeri);
                    jobseekers1.your_img = FileYolu;

                }
                if (resumeimg != null)
                {
                    var filename = resumeimg.FileName;
                    string ext = Path.GetExtension(resumeimg.FileName);

                    string FileYolu = Guid.NewGuid().ToString() + filename;
                    var yuklemeYeri = Server.MapPath("/Content/images/") + FileYolu;
                    resumeimg.SaveAs(yuklemeYeri);
                    jobseekers1.file = FileYolu;

                }
                db.jobseeker.Add(jobseekers1);

             var url1 = new Url()
             {
               jobseeker_id=jobseekers1.jobseekers_id,
               url_link=viewModel.url_link,
               url_name=viewModel.url_name
             };
             var skill1 = new Skill()
             {
                jobseeker_id = jobseekers1.jobseekers_id,
                skill_name = viewModel.skill_name,
                skill_degree = viewModel.skill_degree
             };
             var experiance1 = new Experince()
             {
                jobseeker_id = jobseekers1.jobseekers_id,
                company_name = viewModel.company_name,
                startend_date = viewModel.startend_date,
                description=viewModel.description3
             };
             var education1 = new Education()
             {
                jobseeker_id = jobseekers1.jobseekers_id,
                school_name = viewModel.school_name,
                startent_date = viewModel.startent_date,
                description = viewModel.description2
             };
 
                db.url.Add(url1);
                db.education.Add(education1);
                db.experince.Add(experiance1);
                db.skill.Add(skill1);
                db.SaveChanges();
                return RedirectToAction("Index");
           }


            ViewBag.category_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name", viewModel.category_id);
            ViewBag.jobtype_id = new SelectList(db.jobtype, "jobtype_id", "jobtype_name", viewModel.jobtype_id);
       
           // ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", viewModel.user_id);
            return View(viewModel);
        }

        public ActionResult DeleteJobseeker(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobseekers = db.jobseeker.Find(id);
            if (jobseekers == null)
            {
                return HttpNotFound();
            }
            db.jobseeker.Remove(jobseekers);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
