using System;

namespace WebApplication.DMOs
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
        
        public DateTime LastAccess { get; set; }
        public string TokenJwt { get; set; }

    }
}