using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.DataServices
{
    public class UserDataService : IUserDataService
    {
  
        public User CreateUser(string name, string username, string password = null, string salt = null)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new System.NotImplementedException();
        }


        public async Task<List<User_User>> GetUser(string username)
        {
            var ctx = new DatabaseConnection();
            
            return await ctx.User_User.FromSqlRaw("SELECT * FROM user_user WHERE username = {0}", username).ToListAsync();
        }
    }
}