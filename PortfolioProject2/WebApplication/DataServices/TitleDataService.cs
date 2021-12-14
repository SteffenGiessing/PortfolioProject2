using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class TitleDataService : ITitlesDataService
    {
        public IList<Titles> GetAllTitles(QueryString queryString)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();

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
        
        public IList <PopularTitles> GetPopularTitles(QueryString queryString)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            var result = ctx.PopularTitles.FromSqlRaw
                    ("SELECT titleid, primarytitle, poster, plot, awards, averagerating, startyear, endyear, genres, numvotes  from titles natural join omdb_data natural join ratings where titletype = 'movie' and numvotes > 100000 and averagerating > 8 order by numvotes limit (100)")
                .AsEnumerable();
            
            switch (queryString.OrderBy)
            {
                case "populartitle":
                    result = result.OrderBy(x => x.PrimaryTitle).AsEnumerable();
                    break;
            }

            result = result
                .Skip(queryString.Page * queryString.PageSize)
                .Take(queryString.PageSize);

            return result.ToList();
        }
        
        public IList <TitleSearch> TitleSearch(QueryString queryString, string searchWord)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            var result = ctx.TitleSearch.FromSqlRaw
                ("SELECT primarytitle, titleid, poster, startyear, endyear, genres, plot, awards, averagerating, numvotes from title_search3({0})", searchWord)
                .AsEnumerable();
            
            switch (queryString.OrderBy)
            {
                case "titleSearch":
                    result = result.OrderBy(x => x.PrimaryTitle).AsEnumerable();
                    break;
            }

            result = result
                .Skip(queryString.Page * queryString.PageSize)
                .Take(queryString.PageSize);

            return result.ToList();
        }
        
        /*public async Task<List<TitleSearch>> TitleSearch(string searchWord)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.TitleSearch.FromSqlRaw("SELECT primarytitle, titleid, poster, startyear, endyear, genres, plot, awards, averagerating, numvotes from title_search3({0})", searchWord).ToListAsync();
        }*/

        public async Task<List<Titles>> GetTitleById(string id)
        {
             var ctx = new DatabaseConnection.DatabaseConnection();
              return await ctx.Titles.FromSqlRaw("SELECT * FROM titles WHERE titleid = {0}", id).ToListAsync();
        }
        
        public async Task<List<Titles>> GetTitleByName(string name)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Titles
                .Where(a => a.PrimaryTitle.Contains(name))
                .ToListAsync();
        }

        public async Task<List<Title_Info>> GetInfoSpecificTitle(string id)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Title_Info. FromSqlRaw("SELECT titleid, primarytitle, titletype, originaltitle, isadult, startyear, endyear, runtime, genres, poster, plot from titles natural join omdb_data WHERE titleid = {0}", id).ToListAsync();
        }
        
        // UTILS FOR PAGINATION
                
        public int NumberOffProducts()
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            
            return ctx.Titles.Count();
        }
    }
} 