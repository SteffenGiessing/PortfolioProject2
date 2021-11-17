using System.Collections.Generic;

namespace WebApplication.DTOs
{
    public class User_User_Dto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string TokenJWT { get; set; }
    }
}