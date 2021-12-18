using System.Collections.Generic;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface ISearchHistoryDataService
    {
        IList<User_History> GetAllSearchHistoryFromOneUser(string userid);

        User_History PostNewSearchHistory(string searchtext, int userid);
    }
}