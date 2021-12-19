/*
 * User_ratings table DMO.
 */

namespace WebApplication.DMOs
{
    public class User_Ratings
    {
        public string TitleId { get; set; }

        public int UserId { get; set; }

        public int RateNumber { get; set; }
    }
}