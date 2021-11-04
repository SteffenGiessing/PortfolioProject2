using System.ComponentModel.DataAnnotations;

namespace PortfolioProject2.Models.DMOs
{
    public class Episodes
    {
       [Key]
        public string EpisodeId { get; set; }
        
        public string SeriesId { get; set; }
        
        public int SeasonNumber { get; set; }
        
        public int EpisodeNumber { get; set; }
        
        //for foreign keys
        public virtual Titles Titles { get; set; }
    }
}