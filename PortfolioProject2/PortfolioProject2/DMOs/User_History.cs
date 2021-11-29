namespace PortfolioProject2.Models.DMOs
{
    public class User_History
    {
        public string SearchId { get; set; }
        public string SearchText { get; set; }
        public string UserId { get; set; }
        
        public override string ToString()
        {
            return $"SearchId = {SearchId}";
        }
    }
}