/*
 * Episode table DMO.
 */
namespace WebApplication.DMOs
{
    public class Episodes
    {
        public string EpisodeId { get; set; }

        public string SeriesId { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }
    }
}