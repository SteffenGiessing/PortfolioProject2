using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IRatings
    {
        Task<List<Ratings>> GetRatingBy(string id);
    }
}