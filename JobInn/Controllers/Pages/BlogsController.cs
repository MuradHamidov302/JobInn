﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobInn.Models;
using JobInn.Models.TablePage.Blogs;
using System.IO;
using PagedList;

namespace JobInn.Controllers.Pages
{
    [Authorize]
    public class BlogsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        // GET: Blogs
        public ActionResult Index(int? Page)
        {
            var blog = db.blog.Include(b => b.company).ToList().ToPagedList(Page ?? 1, 6);
            return View(blog);
        }
        [AllowAnonymous]
        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.company_id = new SelectList(db.company, "company_id", "company_name");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "blog_id,blog_title,blog_maintext,blog_alerttext,blog_smallhead,blog_smalltext,blog_datetime,company_id")] Blog blog, HttpPostedFileBase blogimg)
        {
            if (ModelState.IsValid)
            {
                if (blogimg != null)
                {
                    var filename = blogimg.FileName;
                    string ext = Path.GetExtension(blogimg.FileName);

                    string FileYolu = Guid.NewGuid().ToString() + filename;
                    var yuklemeYeri = Server.MapPath("/Content/images/blog/") + FileYolu;
                    blogimg.SaveAs(yuklemeYeri);
                    blog.blog_img = FileYolu;

                }

                db.blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.company_id = new SelectList(db.company, "company_id", "company_name", blog.company_id);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult DeleteBlog(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blogs = db.blog.Find(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            db.blog.Remove(blogs);
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


        [AllowAnonymous]
        public JsonResult AddComment(string name, string comment, int blogid, string Email)
        {
            db.blogcomment.Add(new BlogComment
            {
                user_name = name,
                email = Email,
                comment_text = comment,
                blog_id = blogid
            });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult CommentRply(string name1, string comment1, int blogid1, string Email1)
        {
            db.commentreply.Add(new CommentReply
            {
                user_name = name1,
                email = Email1,
                comment_text = comment1,
                blogcomment_id = blogid1
            });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult CommentPartial(int blog_id)
        {
            var comment = db.blogcomment.Where(c=>c.blog_id==blog_id).ToList();
            return View(comment);
        }
    }
}
