using System;
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
        
        Task<List<PopularTitles>> GetPopularTitlesForFrontPage();
        
        Task<List<PopularTitles>> GetPopularTitles();

        Task<List<Title_Info>> GetInfoSpecificTitle(string id);
        
        Title_Bookmark CreateTitleBookmark(string userid, string titleid);

        Title_Bookmark GetTitleBookmark(string userid, string titleid);

        IList <Title_Bookmark> GetTitleBookmarks(string userid);
        
        bool DeleteTitleBookmark (string userid, string titleid);
    }
    
}