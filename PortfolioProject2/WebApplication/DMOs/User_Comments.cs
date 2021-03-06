/*
 * User_Comments table DMO.
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.DMOs
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