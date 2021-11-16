namespace PortfolioProject2.Models.DMOs
{
    public class UserToCreate
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public byte[] Salt {get; set;}
    }
}