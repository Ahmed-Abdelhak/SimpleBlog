using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please write a comment!")]
        public string Content { get; set; }

        public DateTime? CommentDate { get; set; }

       
        public ApplicationUser Commenter { get; set; }
        [ForeignKey("Commenter")]
        public string CommenterId { get; set; }

        
        public Article Article { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

    }
}