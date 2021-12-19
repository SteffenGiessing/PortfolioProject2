/*
 * OMDB Data service this is where we will execute our commands towards the database regarding actors.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class OmdbDataService : IOmdbDataService
    {
        
        /*
         * Getting OMDB data based on id.
         */
        public async Task<List<Omdb_Data>> GetOmdbById(string id)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Omdb_Data.FromSqlRaw("SELECT * FROM omdb_data WHERE titleid = {0}", id).ToListAsync();
        }
    }
}