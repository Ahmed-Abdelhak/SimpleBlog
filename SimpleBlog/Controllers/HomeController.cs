using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var articles = new ArticleViewModel()
            {
                Articles = _context.Articles.Where(a=>a.IsPublished == true)
                    .Include(a=>a.Category)
                    .Include(a=>a.Publisher)
                    .Include(a => a.Comments)
                    .OrderByDescending(a=>a.DatePublished)
                    .ToList(),
            };
            return View(articles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(Comment comment)
        {
            if (comment.Content != null)
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();

                return PartialView("commentAdd_Partial", comment);
            }

            var article = _context.Articles.Single(c => c.Id == comment.ArticleId);
            var cat = _context.Categories.Single(c => c.Id == article.CategoryId);

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}