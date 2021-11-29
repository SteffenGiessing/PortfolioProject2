using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface IUserDataService
    {
        IList<User_Comments> GetAllComments();

        Task<List<User_Comments>> GetAllCommentsFromOneUser(string userid);

        Task<List<User_Comments>> GetAllCommentsFromOneTitle(string titleid);
        
        IList<User_History> GetAllSearchHistoryFromOneUser(string userid);
        
        User_History PostNewSearchHistory(string userid, string searchtext);

        User_User CreateUser(User_User user);
    }
}