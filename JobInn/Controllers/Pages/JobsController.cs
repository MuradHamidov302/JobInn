﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobInn.Models;
using JobInn.Models.TablePage.Employers;
using JobInn.Models.TablePage;
using PagedList;

namespace JobInn.Controllers.Pages
{
    [Authorize]
    public class JobsController : Controller
    {
        HomeViewModel vm = new HomeViewModel();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        [AllowAnonymous]
        public ActionResult Index()
        {
            vm.jobseeker = db.jobseeker.ToList();
            vm.job = db.job.ToList();
            vm.jobcategory = db.jobcategory.ToList();
            vm.jobtype=db.jobtype.ToList();
            return View(vm);
        }
        [AllowAnonymous]
        public ActionResult JobList(string Search=null, int Page=1)
        {
            var search = db.job.Where(j => j.job_title.Contains(Search)).ToList().ToPagedList(Page, 2);

            return View(search);
        }

        [AllowAnonymous]
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
        [Authorize]
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
        [Authorize]
        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "job_id,concerperson_name,email,job_title,location,city_id,jobcategory_id,salary_package,jobtype_id,clossing_date,company_id,description")] Job job)
        {
            if (ModelState.IsValid)
            {
               
              job.user_id = Convert.ToString(Session["UserId"]);
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
        

        // GET: Jobs/Delete/5
        public ActionResult DeleteJob(int? id)
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

