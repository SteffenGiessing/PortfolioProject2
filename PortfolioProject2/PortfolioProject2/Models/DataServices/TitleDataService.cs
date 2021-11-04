using System.Collections.Generic;
using System.Linq;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataServices
{
    public class TitleDataService : IDataServices
    {
        public IList<Titles> getAllTitles()
        {
            using var ctx = new DatabaseConnection();
            IList<Titles> list = ctx.Titles.ToList();
            return list;
        }
        
        public IQueryable<Titles> getTitleById(string id)
        {
            using var ctx = new DatabaseConnection();

            return ctx.Titles.Where(x => x.TitleId == id).Select(x => x);
        }
    }
}