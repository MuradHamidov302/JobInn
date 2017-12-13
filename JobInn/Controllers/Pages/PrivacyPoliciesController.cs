using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobInn.Areas.Admin.Models;
using JobInn.Models;

namespace JobInn.Controllers.Pages
{
    [Authorize]
    public class PrivacyPoliciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]
        // GET: PrivacyPolicies
        public ActionResult Index()
        {
            return View(db.privacypolicy.ToList());
        }

        // GET: PrivacyPolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivacyPolicy privacyPolicy = db.privacypolicy.Find(id);
            if (privacyPolicy == null)
            {
                return HttpNotFound();
            }
            return View(privacyPolicy);
        }

        // GET: PrivacyPolicies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrivacyPolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pp_id,pp_title,pp_text")] PrivacyPolicy privacyPolicy)
        {
            if (ModelState.IsValid)
            {
                db.privacypolicy.Add(privacyPolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privacyPolicy);
        }

        // GET: PrivacyPolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivacyPolicy privacyPolicy = db.privacypolicy.Find(id);
            if (privacyPolicy == null)
            {
                return HttpNotFound();
            }
            return View(privacyPolicy);
        }

        // POST: PrivacyPolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pp_id,pp_title,pp_text")] PrivacyPolicy privacyPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privacyPolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(privacyPolicy);
        }

        // GET: PrivacyPolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivacyPolicy privacyPolicy = db.privacypolicy.Find(id);
            if (privacyPolicy == null)
            {
                return HttpNotFound();
            }
            return View(privacyPolicy);
        }

        // POST: PrivacyPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrivacyPolicy privacyPolicy = db.privacypolicy.Find(id);
            db.privacypolicy.Remove(privacyPolicy);
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
