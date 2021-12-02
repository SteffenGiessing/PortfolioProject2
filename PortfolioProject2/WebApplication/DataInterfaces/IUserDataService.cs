using System.Collections.Generic;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IUserDataService
    {
        IList<User_Comments> GetAllComments();

        IList <User_Comments> GetUserComments(string userid);

        IList <User_Comments> GetCommentsFromTitle(string titleid);
        
        /*IList<User_History> GetAllSearchHistoryFromOneUser(string userid);
        
        User_History PostNewSearchHistory(string searchtext, string userid);*/

        User_User CreateUser(User_User user);

        User_Comments CreateTitleComments(string userid, string titleid, string commenttext);
    }
}