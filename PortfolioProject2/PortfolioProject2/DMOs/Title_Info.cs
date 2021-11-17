using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PortfolioProject2.Models.DMOs
{
    public class Title_Info
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
        
        public string Poster { get; set; }
        public string Plot { get; set; }

    }
    
}