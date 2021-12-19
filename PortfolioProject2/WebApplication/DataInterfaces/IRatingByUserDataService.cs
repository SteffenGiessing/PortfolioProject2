/*
 * Ratings Interface.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IRatingByUserDataService
    {
        Task<User_Ratings> CreateTitleRating(User_Ratings userRatings);
        Task<List<Ratings>> GetRatingBy(string id);
    }
}