using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioProject2.Models.DMOs;

//why wont this crap work

namespace PortfolioProject2.Models.DataInterfaces
{
    public interface IActorDataService
    {
        IList<Person_Info> GetAllActors();

    }
}