using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? CommentDate { get; set; }

        [ForeignKey("Commenter")]
        public int Fk_CommenterId { get; set; }
        public ApplicationUser Commenter { get; set; }

        [ForeignKey("Article")]
        public int Fk_ArticleId { get; set; }
        public Article Article { get; set; }

    }
}