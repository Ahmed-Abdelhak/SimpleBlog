using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleBlog.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required] public bool IsPublished { get; set; }

        public DateTime? DatePublished { get; set; }


      
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }



        public ApplicationUser Publisher { get; set; }
        [ForeignKey("Publisher")]
        public string PublisherId { get; set; }


        public ICollection<Comment> Comments { get; set; }
    }
}