﻿/*
 * USerToCreateOrLogin DTO.
 */
namespace WebApplication.DTOs
{
    public class UserToCreateOrLogin
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string EmailAddress { get; set; }
            public string Password { get; set; }
            public byte[] PasswordSalt { get; set; }
        }
}
