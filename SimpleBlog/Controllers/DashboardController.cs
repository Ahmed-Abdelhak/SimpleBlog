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
    [Authorize(Roles = BlogRoles.Admin)]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController()
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
            var articleViewModel = new ArticleViewModel()
            {
                Articles = _context.Articles.Include(a => a.Category).Include(a=>a.Publisher).ToList(),
                Categories = _context.Categories.ToList()

        };
            return View(articleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArticle(Article article)
        {
            if (article.Title != null)
            {
                _context.Articles.Add(article);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}