using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class RatingsDataService : IRatings
    {
        public async Task<List<Ratings>> GetRatingBy(string id)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Ratings.FromSqlRaw("SELECT * FROM ratings WHERE titleid = {0}", id).ToListAsync();
        }
    }
}