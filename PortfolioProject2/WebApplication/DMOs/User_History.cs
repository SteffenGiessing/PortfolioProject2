using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication.DMOs
{
   
    public class User_History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SearchId { get; set; }
        public string SearchText { get; set; }
        public string UserId { get; set; }
        
        /*public override string ToString()
        {
            return $"SearchId = {SearchId}";
        }*/
    }
}