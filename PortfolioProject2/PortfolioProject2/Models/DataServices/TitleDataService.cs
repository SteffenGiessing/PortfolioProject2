using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataServices
{
    public class TitleDataService : ITitlesDataService
    {
        public IList<Titles> GetAllTitles()
        {
            using var ctx = new DatabaseConnection();
            IList<Titles> list = ctx.Titles.ToList();
            return list;
        }
        
        public async Task<List<Titles>> GetTitleById(string id)
        {
             var ctx = new DatabaseConnection();
              return  await ctx.Titles.FromSqlRaw("SELECT * FROM titles WHERE titleid = {0}", id).ToListAsync();
        }
        
        public async Task<List<Titles>> GetTitleByName(string name)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Titles
                .Where(a => a.PrimaryTitle.Contains(name))
                .ToListAsync();
        }
    }
}