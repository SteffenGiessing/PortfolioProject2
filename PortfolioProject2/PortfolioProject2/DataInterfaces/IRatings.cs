using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface IRatings
    {
        Task<List<Ratings>> GetRatingBy(string id);
    }
}