using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioProject2.Models.DMOs
{
    [Table("titles")]
    public class Titles
    {
        public string TitlesId { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int RunTime { get; set; }
        public string Genres { get; set; }
        
    }
}