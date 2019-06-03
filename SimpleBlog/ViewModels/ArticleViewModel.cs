using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Models;

namespace SimpleBlog.ViewModels
{
    public class ArticleViewModel
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Article> Articles { get; set; }
        public Article Article { get; set; }
        public Category Category { get; set; }
        public Comment Comment { get; set; }
        public ICollection<Comment> Comments { get; set; }  
    }
}