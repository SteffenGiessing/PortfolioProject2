using System;

namespace WebApplication.DMOs
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public DateTime LastAccess { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}