using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PortfolioProject2.Models.DMOs
{
    [Table("actor")]
    
    public class Person_Info
    {
        [Key]
        public string Pid { get; set; }
        
        public string PrimaryName { get; set; }
        
        public string? BirthYear { get; set; }
        
        public string? DeathYear { get; set; }
    }
}