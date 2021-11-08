using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface IUserDataService
    {
        User CreateUser(string name, string username, string password = null, string salt = null);

        User GetUser(int id);
        Task<List<User_User>> GetUser(string username);
    }
}