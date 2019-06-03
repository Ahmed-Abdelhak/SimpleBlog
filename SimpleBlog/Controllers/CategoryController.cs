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
    public class CategoryController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index(int id, string name)
        {
            var articles = new ArticleViewModel()
            {
                Articles = _context.Articles.Where(a => a.IsPublished == true  && a.CategoryId == id)
                    .Include(a => a.Category)
                    .Include(a => a.Publisher)
                    .OrderByDescending(a => a.DatePublished)
                    .ToList(),
            };
            ViewBag.CatName = name;
            return View(articles);
        }
    }
}