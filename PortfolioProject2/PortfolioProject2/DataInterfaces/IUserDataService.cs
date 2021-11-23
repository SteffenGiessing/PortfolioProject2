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

        Task<List<User_User>> CreateUser(User_User user);

        Task<List<User_User>> GetUserByEmail(Users user);
    }
}