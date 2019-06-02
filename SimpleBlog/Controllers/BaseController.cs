using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class BaseController : Controller
    {
        public CategoryFilterViewModel CategoryFilterViewModel { get; set; }
        private readonly ApplicationDbContext _context;


        public BaseController()
        {
            _context = new ApplicationDbContext();
            this.CategoryFilterViewModel = new CategoryFilterViewModel();
            this.CategoryFilterViewModel.Categories = _context.Categories.ToList();
            this.ViewData["CategoryFilterViewModel"] = this.CategoryFilterViewModel;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

    }
}