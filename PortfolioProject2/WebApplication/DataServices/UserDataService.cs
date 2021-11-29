using System;
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
        
        public IList<User_History> GetAllSearchHistoryFromOneUser(string userid)
        {
            List<User_History> result = new List<User_History>();
            var ctx = new DatabaseConnection();
            foreach (var sh in ctx.User_History)
            {
                if (sh.UserId.Trim() == userid)
                {
                    result.Add(sh);
                }
            }

            return result;
        }
        
        public User_History PostNewSearchHistory(string userid, string searchtext)
        {
            using var ctx = new DatabaseConnection();
            var result = new User_History
            {
                UserId = userid,
                SearchText = searchtext,
                SearchId = NewSearchId()
            };
            ctx.User_History.Add(result);
            ctx.SaveChanges();
            return result;
        }

        public User_User CreateUser(User_User user)
        {
            throw new System.NotImplementedException();
        }
        
        
        
        // Utils
        
        public string NewSearchId()
        {
            using var ctx = new DatabaseConnection();
            var maxSearchId = 0;
            
            
            foreach (var user_history in ctx.User_History )
            {
                var searchid = user_history.SearchId;
                var trimmedUconst = searchid.Remove(0, 2);
                int intSearchId = Int32.Parse(trimmedUconst);

                if (intSearchId > maxSearchId)
                {
                    maxSearchId = intSearchId;
                }
            }
            maxSearchId++;
            var stringSearchId = "smth" + maxSearchId.ToString();

            return stringSearchId;
        }
    }
}

