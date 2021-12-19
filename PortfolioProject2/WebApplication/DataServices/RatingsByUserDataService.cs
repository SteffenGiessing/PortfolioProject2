using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class RatingsByUserDataService : IRatingByUserDataService
    {
        public async Task<User_Ratings> CreateTitleRating(User_Ratings userRatings)
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            var result = new User_Ratings
            {
                UserId = userRatings.UserId,
                TitleId = userRatings.TitleId,
                RateNumber = userRatings.RateNumber
            };
            ctx.User_Ratings.Add(result);
            //check for connection to database
            int a = await ctx.SaveChangesAsync();
            if (a == 0)
            {
                return null;
            }

            return result;
        }
    }
}