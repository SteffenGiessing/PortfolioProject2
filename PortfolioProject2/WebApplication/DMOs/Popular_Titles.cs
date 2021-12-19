using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.DMOs
{
    [Table("popularTitles")]
    public class PopularTitles
    {
        public string PrimaryTitle { get; set; }

        public string TitleId { get; set; }

        public string Poster { get; set; }

        public string StartYear { get; set; }

        public string EndYear { get; set; }

        public string Genres { get; set; }

        public string Plot { get; set; }

        public string Awards { get; set; }

        public int AverageRating { get; set; }

        public int NumVotes { get; set; }
    }
}