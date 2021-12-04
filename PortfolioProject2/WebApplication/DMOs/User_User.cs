using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioProject2.Models.DMOs
{
    public class User_User
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string EmailAddress { get; set; }
            public string Password { get; set; }
            public byte[] PasswordSalt { get; set; }
            public DateTime LastAccess { get; set; }
            public string TokenJwt { get; set; }
        }
    
}