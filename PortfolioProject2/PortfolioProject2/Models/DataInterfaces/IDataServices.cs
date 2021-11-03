using System.Collections.Generic;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models
{
    public interface IDataServices
    {
        IList<Titles> getAllTitles();
    }
}