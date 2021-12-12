using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.DMOs
{
    [Table("popularTitles")]
    public class PopularTitles
    {
        public string TitleId { get; set; }
        public string PrimaryTitle { get; set; }
        
        public string Poster { get; set; }
        
        public string Plot { get; set; }
        
        public string Awards { get; set; }
    }
}