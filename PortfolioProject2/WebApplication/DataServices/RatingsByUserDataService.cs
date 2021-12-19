/*
 * Ratings Data service this is where we will execute our commands towards the database regarding actors.
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class RatingsByUserDataService : IRatingByUserDataService
    {   
        /*
         * Creating a rating for a title
         */
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
        /*
         * Getting rating on title.
         */
        public async Task<List<Ratings>> GetRatingBy(string id)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Ratings.FromSqlRaw("SELECT * FROM ratings WHERE titleid = {0}", id).ToListAsync();        }
    }
}