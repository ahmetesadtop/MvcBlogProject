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
    public class HomeController : Controller
    {
        private ArticleDbContext db = new ArticleDbContext();

        //
        // GET: /Admin/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            return View(db.Articles.OrderBy(x => x.Date).ToList().ToPagedList(page, 10));
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
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}