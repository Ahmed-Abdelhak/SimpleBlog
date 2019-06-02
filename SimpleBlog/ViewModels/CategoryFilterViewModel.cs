using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Models;

namespace SimpleBlog.ViewModels
{
    public class CategoryFilterViewModel
    {
        public ICollection<Category> Categories { get; set; }
    }
}