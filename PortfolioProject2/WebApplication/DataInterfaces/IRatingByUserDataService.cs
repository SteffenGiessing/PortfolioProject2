using System.Threading.Tasks;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IRatingByUserDataService
    {
        Task<User_Ratings> CreateTitleRating(User_Ratings userRatings);
    }
}