namespace PortfolioProject2.Models.DMOs
{
    public class User_User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public  User_User()
        {
            UserId = 1;
            FirstName = "Steffen";
            LastName = "Giessing";
            UserName = "Stef";
            EmailAddress = "Stef@gmail.com";
            PasswordSalt = "Stef";
            PasswordHash = "Stef";
            
        }
    }
}