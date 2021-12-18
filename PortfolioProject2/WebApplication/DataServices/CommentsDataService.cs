using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class CommentsDataService : ICommentsDataService
    {
        //Comment GET
        public IList<User_Comments> GetAllComments()
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            IList<User_Comments> list = ctx.User_Comments.ToList();
            return list;
        }

        public async Task<List<User_Comments>> GetUserComments(int userid)
        {
            var result = new User_Comments();
            using var ctx = new DatabaseConnection.DatabaseConnection();
            foreach (var uc in ctx.User_Comments)
            {
                result.UserId = userid;
                result.CommentText = uc.CommentText;
                result.TitleId = uc.TitleId;
            }

            return await ctx.User_Comments.FromSqlRaw("SELECT * FROM user_comments WHERE userid = {0}", userid)
                .ToListAsync();
        }

        public IList<User_Comments> GetCommentsFromTitle(string titleid)
        {
            var result = new List<User_Comments>();
            var ctx = new DatabaseConnection.DatabaseConnection();
            foreach (var uc in ctx.User_Comments)
                if (uc.TitleId.Trim() == titleid)
                    result.Add(uc);
            return result;
        }

        // Comment POST
        public async Task<User_Comments> CreateTitleComments(User_Comments userComments)
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            var result = new User_Comments
            {
                UserId = userComments.UserId,
                TitleId = userComments.TitleId,
                CommentText = userComments.CommentText,
                CommentTime = DateTime.Now
            };
            ctx.User_Comments.Add(result);
            //check for connection to database
            var a = await ctx.SaveChangesAsync();
            if (a == 0) return null;
            return result;
        }
    }
}