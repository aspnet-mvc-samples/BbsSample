using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BbsSample.Models;
using Microsoft.AspNet.Identity;

namespace BbsSample.Controllers
{
    [RoutePrefix("Comments")]
    public class CommentsController : Controller
    {
        private BbsDbContext db = new BbsDbContext();

        // GET: Comments
        [Route("")]
        [Route("Index")]
        [Route("Index/{page}")]
        [Route("~/")]
        [Route("~/page{page}")]
        public ActionResult Index(int? page)
        {
            ViewBag.Page = page;
            var comments = from comment in db.Comments
                           orderby comment.Created descending
                           select comment;
            //db.Comments.OrderByDescending(item => item.Created);
            return View(comments.ToList());
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            Comment comment = new Comment { UserName = User.Identity.GetUserName(), Body = "" };
            if (string.IsNullOrEmpty(comment.UserName)) comment.UserName = "名無し";
            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "UserName,Body")] Comment comment)
        {
            comment.Created = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
