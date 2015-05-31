using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using MyBlog.DataAccessList;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace MyBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ArticleDbContext db = new ArticleDbContext();

        //
        // GET: /Admin/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(int page=1)
        {
            return View(db.Articles.OrderBy(x=>x.Date).ToList().ToPagedList(page,5));
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }


        public ActionResult Image()
        {
            return RedirectToAction("Create");
        }

        [HttpPost]
        public ActionResult Image(HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {
                var filename = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/img"), filename);
                file.SaveAs(path);
            }


            return RedirectToAction("Create");
        }


        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        //[HttpPost]
        //public ActionResult Create(Article article)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Articles.Add(article);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(article);
        //}
        [HttpPost]
        public ActionResult Create(Article article, HttpPostedFileBase file)
        {
            if (!(file == null))
            {
                string ImageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/img/" + ImageName);
                file.SaveAs(physicalPath);
                article.Image = "~/img/" + ImageName;
            }
            else
            {
                string physicalPath = Server.MapPath("~/img/Empty.jpeg");
                article.Image = "~/img/Empty.jpeg";
            }
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Admin/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Article article)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(article).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(article);
        //}
        [HttpPost]
        public ActionResult Edit(Article article, HttpPostedFileBase file)
        {
            if (!(file == null))
            {
                string ImageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/img/" + ImageName);
                file.SaveAs(physicalPath);
                article.Image = "~/img/" + ImageName;
            }
            else
            {
                string physicalPath = Server.MapPath("~/img/Empty.jpeg");
                article.Image = "~/img/Empty.jpeg";
            }
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}