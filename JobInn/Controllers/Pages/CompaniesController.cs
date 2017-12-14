using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobInn.Models;
using JobInn.Models.TablePage;
using System.IO;

namespace JobInn.Controllers.Pages
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        HomeViewModel vm = new HomeViewModel();
        [AllowAnonymous]
        // GET: Companies
        public ActionResult Index()
        {
            vm.job = db.job.ToList();
            vm.jobcategory = db.jobcategory.ToList();
            vm.company = db.company.ToList();
           
            return View(vm);
        }
        [AllowAnonymous]
        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "company_id,company_name,tagline,description,video_link,web_site,facebook_link,googleplus_link,twitter_link,linkedin_link,youtube_link")] Company company, HttpPostedFileBase compimg)
        {
            if (ModelState.IsValid)
            {
                if (compimg != null)
                {
                    var filename = compimg.FileName;
                    string ext = Path.GetExtension(compimg.FileName);

                    string FileYolu = Guid.NewGuid().ToString() + filename;
                    var yuklemeYeri = Server.MapPath("/Content/images/companies/") + FileYolu;
                    compimg.SaveAs(yuklemeYeri);
                    company.logo_img = FileYolu;

                }

                company.user_id = Convert.ToString(Session["UserId"]);
                db.company.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", company.user_id);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", company.user_id);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "company_id,company_name,tagline,description,video_link,web_site,facebook_link,googleplus_link,twitter_link,linkedin_link,youtube_link,logo_img,user_id")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "Id", "first_name", company.user_id);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.company.Find(id);
            db.company.Remove(company);
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
