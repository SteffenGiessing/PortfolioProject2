using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication.DMOs
{
   
    public class User_History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SearchId { get; set; }
        public string SearchText { get; set; }
        public int UserId { get; set; }
    }
}