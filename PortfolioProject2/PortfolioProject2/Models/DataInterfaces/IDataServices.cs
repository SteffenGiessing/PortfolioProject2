using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface IDataServices
    {
        IList<Titles> getAllTitles();

        Task<List<Titles>> getTitleById(string id);
    }
}