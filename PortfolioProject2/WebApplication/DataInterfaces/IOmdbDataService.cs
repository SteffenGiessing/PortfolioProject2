using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IOmdbDataService
    {
        Task<List<Omdb_Data>> GetOmdbById(string id);
    }
}