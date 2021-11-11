using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface ITitlesDataService
    {
        IList<Titles> GetAllTitles(QueryString queryString);

        int NumberOffProducts();

        Task<List<Titles>> GetTitleById(string id);
        
        Task<List<Titles>> GetTitleByName(string id);
        
        Task<List<TitleSearch>> TitleSearch(string titleSearch);
        
        Task<List<PopularTitles>> GetPopularTitles();

        Task<List<Titles>> GetInfoSpecificTitle(string id);
    }
    
}