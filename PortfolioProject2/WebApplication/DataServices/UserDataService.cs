using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;
using User_History = WebApplication.DMOs.User_History;

namespace WebApplication.DataServices
{
    public class UserDataService : IUserDataService
    {
        public DatabaseConnection ctx { get; set; }
        
        //User Comments
        public IList<User_Comments> GetAllComments()
        {
            using var ctx = new DatabaseConnection();
            IList<User_Comments> list = ctx.User_Comments.ToList();
            return list;
        }

        public IList<User_Comments> GetUserComments(string userid)
        {
            IList<User_Comments> result = new List<User_Comments>();
            using var ctx = new DatabaseConnection();
            
            foreach (var uc in ctx.User_Comments)
            {
                if (uc.UserId.Trim() == userid)
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

        public User_Comments CreateTitleComments(string userid, string titleid, string commenttext)
        {
            using var ctx = new DatabaseConnection();
            var result = new User_Comments
            {
                UserId = userid,
                TitleId = titleid,
                CommentText = commenttext,
                CommentTime = DateTime.Now,
                //CommentId = NewSearchId()
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
        
        
        //User searchhistory--------------------------
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
        
        public User_History PostNewSearchHistory(string searchtext, string userid)
        {
            using var ctx = new DatabaseConnection();
            var result = new User_History
            {
                SearchText = searchtext,
                UserId = userid
            };
            ctx.User_History.Add(result);
            ctx.SaveChanges();
            return result;
        }
        
        /*public User_History PostNewSearchHistory(User_History history)
        {
            using var ctx = new DatabaseConnection();
            ctx.User_History.FromSqlRaw(
                "INSERT INTO user_history(searchtext, userid) VALUES ({0}, {1})", 
                history.SearchText, history.UserId).FirstOrDefault();
        
            return history;
        }*/

        public User_User CreateUser(User_User user)
        {
            throw new System.NotImplementedException();
        }
        
        
        
        // Utils
        
        /*public string NewSearchId()
        {
            using var ctx = new DatabaseConnection();
            var maxSearchId = 0;
            
            
            foreach (var user_history in ctx.User_History )
            {
                var searchid = user_history.SearchId;
                var trimmedUconst = searchid;
                int intSearchId = Int32.Parse(trimmedUconst);

                if (intSearchId > maxSearchId)
                {
                    maxSearchId = intSearchId;
                }
            }
            maxSearchId++;
            var stringSearchId = maxSearchId.ToString();

            return stringSearchId;
        }*/
    }
}

