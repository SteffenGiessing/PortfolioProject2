using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;
using User_User = WebApplication.DMOs.User_User;

namespace WebApplication.DataInterfaces
{
    public interface IUserDataService
    {
        IList<User_Comments> GetAllComments();

        Task<List<User_Comments>> GetAllCommentsFromOneUser(string userid);

        Task<List<User_Comments>> GetAllCommentsFromOneTitle(string titleid);

        User_User CreateUser(User_User user);

        Task<User_User> GetUserByEmail(string email);
    }
}