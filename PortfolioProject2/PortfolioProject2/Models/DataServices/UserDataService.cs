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
        
    }
}

