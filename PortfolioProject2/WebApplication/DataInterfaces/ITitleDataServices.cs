/*
 * Title Interface.
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface ITitlesDataService
    {
        IList<Titles> GetAllTitles(QueryString queryString);

        IList<PopularTitles> GetPopularTitles(QueryString queryString);

        Task<List<TitleSearch>> TitleSearch(string titleSearch);

        int NumberOffProducts();

        Task<List<Titles>> GetTitleById(string id);

        Task<List<Titles>> GetTitleByName(string id);

        Task<List<Title_Info>> GetInfoSpecificTitle(string id);
    }
}