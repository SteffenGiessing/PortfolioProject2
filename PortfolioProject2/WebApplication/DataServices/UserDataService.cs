﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class UserDataService : IUserDataService
    {
        private int verify;

        public async Task<User_User> CreateUser(User_User user)
        {
            //   resultat.LastAccess = Convert.ToDateTime(DateTime.Now);
            var ctx = new DatabaseConnection.DatabaseConnection();

            var resultat = new User_User();
            //var regexItem = new Regex("^[a-zA-Z0-9 ]*$");


            if (user.FirstName.Any(c => char.IsDigit(c))) /* || regexItem.IsMatch(user.FirstName)) */
                return WrongData("Firstname cannot contain numbers.");
            resultat.FirstName = user.FirstName;
            if (user.LastName.Any(c => char.IsDigit(c))) /*|| regexItem.IsMatch(user.LastName)) */
                return WrongData("Lastname cannot contain numbers.");
            resultat.LastName = user.LastName;

            if (user.UserName.Any(c => char.IsDigit(c)))
                return WrongData("Username cannot contain numbers.");
            resultat.UserName = user.UserName;

            if (!user.EmailAddress.Contains("@"))
                return WrongData("Email needs to contain @");
            resultat.EmailAddress = user.EmailAddress;

            resultat.Password = user.Password;
            resultat.PasswordSalt = user.PasswordSalt;
            resultat.LastAccess = Convert.ToDateTime(DateTime.Now);

            await ctx.User_User.AddAsync(resultat);
            verify = await ctx.SaveChangesAsync();

            if (verify == 0) return null;

            if (verify == 1)
                return ctx.User_User.FromSqlRaw("SELECT * FROM user_user WHERE emailaddress = {0}", user.EmailAddress)
                    .FirstOrDefault();
            return ctx.User_User.FromSqlRaw("SELECT * FROM user_user WHERE emailaddress = {0}", user.EmailAddress)
                .FirstOrDefault();
        }

        public Task<User_User> GetUserByEmail(string email)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return ctx.User_User.FromSqlRaw("SELECT * FROM user_user WHERE emailaddress = {0}", email)
                .FirstOrDefaultAsync();
        }

        public Task<User_User> ValidatePassword(string email, string hashed)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return ctx.User_User
                .FromSqlRaw("SELECT * FROM user_user WHERE emailaddress = {0} AND password = {1}", email, hashed)
                .FirstOrDefaultAsync();
        }

        public async Task<User_User> DeleteUser(User_User user)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            var result = GetUserByEmail(user.EmailAddress).Result;
            ctx.User_User.Remove(ctx.User_User.Single(a => a.UserId == result.UserId));
            verify = ctx.SaveChanges();
            if (verify == 0) return null;

            if (verify == 1) return result;
            return null;
        }

        public async Task<User_User> UpdateUser(User_User user)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            var result = ctx.User_User.FirstOrDefault(id => id.UserId == user.UserId);
            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.UserName = user.UserName;
                result.EmailAddress = user.EmailAddress;
                await ctx.SaveChangesAsync();
                return await GetUserByEmail(user.EmailAddress);
            }

            return WrongData(user.FirstName);
        }


        // Utilsprobuilds
        public User_User WrongData(string wrongNaming)
        {
            var wrongData = new User_User
            {
                FirstName = "null"
            };
            return wrongData;
        }
    }
}