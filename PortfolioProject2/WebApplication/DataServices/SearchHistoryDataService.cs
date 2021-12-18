﻿using System;
using System.Collections.Generic;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class SearchHistoryDataService : ISearchHistoryDataService
    {
        public IList<User_History> GetAllSearchHistoryFromOneUser(string userid)
        {
            throw new NotImplementedException();
        }

        // Post Search History
        public User_History PostNewSearchHistory(string searchtext, int userid)
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            var result = new User_History
            {
                SearchText = searchtext,
                UserId = userid
            };
            ctx.User_History.Add(result);
            var a = ctx.SaveChanges();
            if (a == 0) return null;
            return result;
        }

        // GET Search History
        public IList<User_History> GetAllSearchHistoryFromOneUser(int userid)
        {
            var result = new List<User_History>();
            var ctx = new DatabaseConnection.DatabaseConnection();
            foreach (var sh in ctx.User_History)
                if (sh.UserId == userid)
                    result.Add(sh);

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