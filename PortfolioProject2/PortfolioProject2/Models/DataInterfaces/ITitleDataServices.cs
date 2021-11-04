using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface ITitlesDataService
    {
        IList<Titles> GetAllTitles();

        Task<List<Titles>> GetTitleById(string id);
    }
    
}