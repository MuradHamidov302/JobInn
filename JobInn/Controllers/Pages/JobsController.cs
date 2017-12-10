using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobInn.Models;
using JobInn.Models.TablePage.Employers;

namespace JobInn.Controllers.Pages
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.job.Include(j => j.city).Include(j => j.company).Include(j => j.jobcategory).Include(j => j.jobtype).Include(j => j.user);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.city, "city_id", "city_name");
            ViewBag.company_id = new SelectList(db.company, "company_id", "company_name");
            ViewBag.jobcategory_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name");
            ViewBag.jobtype_id = new SelectList(db.jobtype, "jobtype_id", "jobtype_name");
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "job_id,concerperson_name,email,job_title,location,city_id,jobcategory_id,salary_package,jobtype_id,clossing_date,company_id,user_id")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.job.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.city, "city_id", "city_name", job.city_id);
            ViewBag.company_id = new SelectList(db.company, "company_id", "company_name", job.company_id);
            ViewBag.jobcategory_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name", job.jobcategory_id);
            ViewBag.jobtype_id = new SelectList(db.jobtype, "jobtype_id", "jobtype_name", job.jobtype_id);
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", job.user_id);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.city, "city_id", "city_name", job.city_id);
            ViewBag.company_id = new SelectList(db.company, "company_id", "company_name", job.company_id);
            ViewBag.jobcategory_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name", job.jobcategory_id);
            ViewBag.jobtype_id = new SelectList(db.jobtype, "jobtype_id", "jobtype_name", job.jobtype_id);
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", job.user_id);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "job_id,concerperson_name,email,job_title,location,city_id,jobcategory_id,salary_package,jobtype_id,clossing_date,company_id,user_id")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.city, "city_id", "city_name", job.city_id);
            ViewBag.company_id = new SelectList(db.company, "company_id", "company_name", job.company_id);
            ViewBag.jobcategory_id = new SelectList(db.jobcategory, "jobcategory_id", "jobcategory_name", job.jobcategory_id);
            ViewBag.jobtype_id = new SelectList(db.jobtype, "jobtype_id", "jobtype_name", job.jobtype_id);
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", job.user_id);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.job.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.job.Find(id);
            db.job.Remove(job);
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
