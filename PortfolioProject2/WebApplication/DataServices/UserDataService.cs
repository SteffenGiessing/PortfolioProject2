using System;
using System.Collections.Generic;
using System.Linq;
using PortfolioProject2.Models;
using PortfolioProject2.Models.DMOs;
using IUserDataService = WebApplication.DataInterfaces.IUserDataService;

namespace WebApplication.DataServices
{
    public class UserDataService : IUserDataService
    {
        //User GET
        public IList<User_Comments> GetAllComments()
        {
            using var ctx = new DatabaseConnection();
            IList<User_Comments> list = ctx.User_Comments.ToList();
            return list;
        }

        public IList<User_Comments> GetUserComments(int userid)
        {
            IList<User_Comments> result = new List<User_Comments>();
            using var ctx = new DatabaseConnection();
            
            foreach (var uc in ctx.User_Comments)
            {
                if (uc.UserId == userid)
                {
                    result.Add(uc);
                }
            }
            return result;
        }

        public IList<User_Comments> GetCommentsFromTitle(string titleid)
        {
            List<User_Comments> result = new List<User_Comments>();
            var ctx = new DatabaseConnection();
            foreach (var uc in ctx.User_Comments)
            {
                if (uc.TitleId.Trim() == titleid)
                {
                    result.Add(uc);
                }
            }
            return result;
        }

        // USER POST
        public User_Comments CreateTitleComments(int userid, string titleid, string commenttext)
        {
            using var ctx = new DatabaseConnection();
            var result = new User_Comments
            {
                UserId = userid,
                TitleId = titleid,
                CommentText = commenttext,
                CommentTime = DateTime.Now,
            };
            ctx.User_Comments.Add(result);
            //check for connection to database
            int a = ctx.SaveChanges();
            if (a == 0)
            {
                return null;
            }
            return result;
        }

        public User_User CreateUser(User_User user)
        {
            throw new System.NotImplementedException();
        }
    }
}

