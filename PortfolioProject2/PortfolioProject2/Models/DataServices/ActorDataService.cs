using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;


namespace PortfolioProject2.Models.DataServices
{
    public class ActorDataService : IActorDataService
    {
        public IList<Person_Info> GetAllActors()
        {
            using var ctx = new DatabaseConnection();
            IList<Person_Info> list = ctx.Person_Info.ToList();
            return list;
        }
    }
}