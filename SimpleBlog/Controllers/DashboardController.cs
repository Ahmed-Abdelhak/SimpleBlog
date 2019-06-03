using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Microsoft.Win32.SafeHandles;
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
                Articles = _context.Articles.Include(a => a.Category).Include(a => a.Publisher).ToList(),
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

            if (article.ArticleImage != null && article.ArticleImage.ContentLength > 0)
            {
                //var articleDb = _context.Articles.Single(a => a.Title == article.Title);
                var title = HelperFunctions.MakeValidFileName(article.Title);
                var fileExt = Path.GetExtension(article.ArticleImage.FileName);
                var fnm = title + ".png";
                if (fileExt.ToLower().EndsWith(".png") || fileExt.ToLower().EndsWith(".jpg")
                ) // Important for security if saving in webroot
                {
                    var filePath = HostingEnvironment.MapPath("~/Content/images/Articles/") + fnm;
                    var directory = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/images/Articles/"));
                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }

                    ViewBag.FilePath = filePath.ToString();
                    article.ArticleImage.SaveAs(filePath);
                }
            }
            return RedirectToAction("Index");

        }

       
    }
}
