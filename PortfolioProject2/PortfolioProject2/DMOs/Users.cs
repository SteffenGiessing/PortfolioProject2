using System;

namespace PortfolioProject2.Models.DMOs
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string Nickname { get; set; }
        public DateTime AccountCreation { get; set; }
        public DateTime LastAccess { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
    }
}