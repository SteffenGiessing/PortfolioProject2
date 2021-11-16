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
        /*public IList<Titles> GetAllTitles()
        {
            using var ctx = new DatabaseConnection();
            IList<Titles> list = ctx.Titles.ToList();
            return list;
        }*/

        private readonly List<Titles> _titles = new List<Titles>();
        
        public IList<Titles> GetAllTitles(QueryString queryString)
        {
            var ctx = new DatabaseConnection();

            var result = ctx.Titles.AsEnumerable();

            switch (queryString.OrderBy)
            {
                case "title":
                    result = result.OrderBy(x => x.PrimaryTitle).AsEnumerable();
                    break;
            }

            result = result
                .Skip(queryString.Page * queryString.PageSize)
                .Take(queryString.PageSize);

            return result.ToList();
        }

        public int NumberOffProducts()
        {
            var ctx = new DatabaseConnection();
            
            return ctx.Titles.Count();
        }

        public async Task<List<Titles>> GetTitleById(string id)
        {
             var ctx = new DatabaseConnection();
              return await ctx.Titles.FromSqlRaw("SELECT * FROM titles WHERE titleid = {0}", id).ToListAsync();
        }
        
        public async Task<List<Titles>> GetTitleByName(string name)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Titles
                .Where(a => a.PrimaryTitle.Contains(name))
                .ToListAsync();
        }
        public async Task<List<TitleSearch>> TitleSearch(string searchWord)
        {
            var ctx = new DatabaseConnection();
            return await ctx.TitleSearch.FromSqlRaw("SELECT primarytitle, titleid from title_search3({0})", searchWord).ToListAsync();
        }
        
        public async Task<List<PopularTitles>> GetPopularTitlesForFrontPage()
        {
            var ctx = new DatabaseConnection();
            return await ctx.PopularTitles. FromSqlRaw
                ("SELECT primarytitle, poster from titles natural join omdb_data natural join ratings where numvotes > 100000 and startyear = '2019' and averagerating > 8 order by numvotes limit (10)").
                ToListAsync();
            
        }

        public async Task<List<PopularTitles>> GetPopularTitles()
        {
            var ctx = new DatabaseConnection();
            return await ctx.PopularTitles.FromSqlRaw
                    ("SELECT primarytitle, poster, plot, awards from titles natural join omdb_data natural join ratings where numvotes > 100000 and averagerating > 8 order by numvotes limit (100)")
                .ToListAsync();
        }
        
        public async Task<List<Titles>> GetInfoSpecificTitle(string id)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Titles. FromSqlRaw("SELECT titleid, primarytitle, titletype, originaltitle, isadult, startyear, endyear, runtime, genres from titles WHERE titleid = {0}", id).ToListAsync();
        }
        
    }
}