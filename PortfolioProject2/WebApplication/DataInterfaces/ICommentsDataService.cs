using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface ICommentsDataService
    {
        IList<User_Comments> GetAllComments();

        Task <User_Comments> GetUserComments(int userid);

        IList <User_Comments> GetCommentsFromTitle(string titleid);
        
        Task <User_Comments> CreateTitleComments(User_Comments userComments);
    }
}