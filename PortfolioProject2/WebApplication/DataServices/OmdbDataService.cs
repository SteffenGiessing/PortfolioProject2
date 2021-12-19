using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class OmdbDataService : IOmdbDataService
    {
        public async Task<List<Omdb_Data>> GetOmdbById(string id)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Omdb_Data.FromSqlRaw("SELECT * FROM omdb_data WHERE titleid = {0}", id).ToListAsync();
        }
    }
}