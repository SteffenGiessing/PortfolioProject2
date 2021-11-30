using System;

namespace PortfolioProject2.Models.DMOs
{
    public class User_User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public DateTime lastaccess { get; set; }
        public string TokenJWT { get; set; }

    }
}