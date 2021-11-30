using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioProject2.Models.DMOs
{
    public class User_Comments
    {
        public string CommentText { get; set; }
        public string UserId { get; set; }
        public string TitleId { get; set; }
        public DateTime CommentTime { get; set; }
        
    }
}