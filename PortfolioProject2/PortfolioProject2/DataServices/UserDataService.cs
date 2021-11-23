using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataServices
{
    public class UserDataService : IUserDataService
    {
        public IList<User_Comments> GetAllComments()
        {
            using var ctx = new DatabaseConnection();
            IList<User_Comments> list = ctx.User_Comments.ToList();
            return list;
        }

        public async Task<List<User_Comments>> GetAllCommentsFromOneUser(string userid)
        {
            var ctx = new DatabaseConnection();
            return await ctx.User_Comments
                .FromSqlRaw("SELECT * FROM user_comments WHERE userid = {0}", userid)
                .ToListAsync();
        }

        public async Task<List<User_Comments>> GetAllCommentsFromOneTitle(string titleid)
        {
            var ctx = new DatabaseConnection();
            return await ctx.User_Comments
                .FromSqlRaw("SELECT * FROM user_comments WHERE titleid = {0}", titleid)
                .ToListAsync();
        }

        public async Task<List<User_User>> CreateUser(User_User user)
        {
            var ctx = new DatabaseConnection();
            return await ctx.User_User.FromSqlRaw("INSERT INTO user_user(firstname,lastname,username,emailaddress,token,password) VALUE ({0},{1},{2},{3},{4},{5})",
                user.FirstName, user.LastName,user.UserName,user.EmailAddress,user.TokenJWT,user.PasswordHash)
                .ToListAsync();
            
        }

        public async Task<List<User_User>> GetUserByEmail(Users user)
        {
            throw new System.NotImplementedException();
        }
    }
}

