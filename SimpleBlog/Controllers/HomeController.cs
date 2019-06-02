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
                Articles = _context.Articles.Include(a=>a.Category).Include(a=>a.Publisher).OrderByDescending(a=>a.DatePublished).ToList()
            };
            return View(articles);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}