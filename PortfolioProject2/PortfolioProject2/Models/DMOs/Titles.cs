using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PortfolioProject2.Models.DMOs
{
    [Table("titles")]
    public class Titles
    {
        public string TitleId { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int? RunTime { get; set; }
        public string Genres { get; set; }
        
        //for foreign keys
        public virtual Title_Known_As Title_Known_As { get; set;} 
        public virtual Episodes Episodes { get; set;}
        public virtual Genre Genre { get; set;} 
        public virtual Omdb_Data Omdb_Data { get; set;} 

        
    }
}