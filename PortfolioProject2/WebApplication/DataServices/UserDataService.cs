using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.DMOs;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;
using IUserDataService = WebApplication.DataInterfaces.IUserDataService;
using User_User = WebApplication.DMOs.User_User;

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

        public User_User CreateUser(User_User user)
        {   
            user.TokenJwt = "null";
            user.PasswordHash = "nullPass";

            var ctx = new DatabaseConnection();
                
            ctx.User_User.FromSqlRaw("INSERT INTO user_user(firstname,lastname,username,emailaddress,password, passwordhash) VALUES ({0},{1},{2},{3},{4},{5})",
                user.FirstName, user.LastName,user.UserName,user.EmailAddress,user.PasswordHash, user.PasswordHash);
            
            
            return ctx.User_User.FromSqlRaw("SELECT * FROM user_user WHERE emailaddress = {0}",user.EmailAddress).FirstOrDefault();
        }

        public async Task<User_User> GetUserByEmail(string email)
        { 
            var ctx = new DatabaseConnection();

            return await ctx.User_User.FromSqlRaw("SELECT userid, firstname, lastname, username, emailaddress FROM user_user WHERE emailaddress = {0}",
                email).FirstOrDefaultAsync();
        }
    }
}

