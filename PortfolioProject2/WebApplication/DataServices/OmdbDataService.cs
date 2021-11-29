using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataServices
{
    public class OmdbDataService : IOmdbDataService
    {
        public async Task<List<Omdb_Data>> GetOmdbById(string id)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Omdb_Data.FromSqlRaw("SELECT * FROM omdb_data WHERE titleid = {0}", id).ToListAsync();
        }
    }
}