/*
 * Person_in_title table DMO.
 */
namespace WebApplication.DMOs
{
    public class Person_In_Title
    {
        public string TitleId { get; set; }

        public int Ordering { get; set; }

        public string Pid { get; set; }

        public string Role { get; set; }

        public string Job { get; set; }

        public string CharName { get; set; }
    }
}