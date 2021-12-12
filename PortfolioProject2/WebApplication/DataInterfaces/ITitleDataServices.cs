using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2;
using PortfolioProject2.Models.DMOs;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface ITitlesDataService
    {
        IList<Titles> GetAllTitles(QueryString queryString);
        IList<PopularTitles> GetPopularTitles(QueryString queryString);

        Task<List<Titles>> GetTitleById(string id);
        
        Task<List<Titles>> GetTitleByName(string id);
        
        Task<List<TitleSearch>> TitleSearch(string titleSearch);
        
        Task<List<PopularTitles>> GetPopularTitlesForFrontPage();
        

        Task<List<Title_Info>> GetInfoSpecificTitle(string id);
        
        int NumberOffProducts();
        int NumberOfPopular();
    }
    
}