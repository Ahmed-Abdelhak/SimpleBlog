﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }  
    }
}