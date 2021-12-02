using System.Collections.Generic;
using PortfolioProject2.Models.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IUserDataService
    {
        IList<User_Comments> GetAllComments();

        IList <User_Comments> GetUserComments(int userid);

        IList <User_Comments> GetCommentsFromTitle(string titleid);
        
        User_User CreateUser(User_User user);

        User_Comments CreateTitleComments(int userid, string titleid, string commenttext);
    }
}