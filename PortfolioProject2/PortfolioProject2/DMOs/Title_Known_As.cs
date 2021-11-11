namespace PortfolioProject2.Models.DMOs
{
    public class Title_Known_As
    {
        
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public bool IsOriginalTitle { get; set; }
        
        public virtual Titles Titles { get; set; } // for foreign key from Titles

    }
}