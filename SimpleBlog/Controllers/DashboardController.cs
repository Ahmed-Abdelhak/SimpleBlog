using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Models;

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
            var articles = _context.Articles.Include(a => a.Category).ToList();
            return View(articles);
        }
    }
}