using System.Collections.Generic;
using System.Linq;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface IDataServices
    {
        IList<Titles> getAllTitles();

        IQueryable<Titles> getTitleById(string id);
    }
}