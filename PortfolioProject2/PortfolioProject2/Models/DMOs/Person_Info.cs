using System.ComponentModel.DataAnnotations;

namespace PortfolioProject2.Models.DMOs
{
    public class Person_Info
    {
        [Key]
        public string Pid { get; set; }
        
        public string PrimaryName { get; set; }
        
        public int BirthYear { get; set; }
        
        public int DeathYear { get; set; }
    }
}