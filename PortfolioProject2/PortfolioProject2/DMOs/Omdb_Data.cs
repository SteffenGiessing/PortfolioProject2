namespace PortfolioProject2.Models.DMOs
{
    public class Omdb_Data
    {
        public string TitleId { get; set; }
        public string Poster { get; set; }
        public string Awards { get; set; }
        public string Plot { get; set; }
        
        //for foreign keys
        public virtual Titles Titles { get; set; }
    }
}