using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.DTOs
{
    public class User_Comments_Dto
    {
        public string CommentText { get; set; }
        public string UserId { get; set; }
        public string TitleId { get; set; }
        public DateTime CommentTime { get; set; }
        public string CommentId { get; set; }
    }
}