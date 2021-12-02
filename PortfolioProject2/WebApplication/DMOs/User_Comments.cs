using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioProject2.Models.DMOs
{
    public class User_Comments
    {

        public string CommentText { get; set; }
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public DateTime CommentTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        
    }
}