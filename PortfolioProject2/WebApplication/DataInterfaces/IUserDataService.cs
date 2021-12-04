using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IUserDataService
    {
        Task<User_User> CreateUser(User_User user);

        Task<User_User> GetUserByEmail(string user);

        Task<User_User> ValidatePassword(string email, string hashed);

        Task<User_User> DeleteUser(User_User user);
      
    }
}