using System.Collections.Generic;
using User_History = WebApplication.DMOs.User_History;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface ISearchHistoryDataService
    {
        IList<User_History> GetAllSearchHistoryFromOneUser(string userid);
        
        User_History PostNewSearchHistory(string searchtext, string userid);

    }
}