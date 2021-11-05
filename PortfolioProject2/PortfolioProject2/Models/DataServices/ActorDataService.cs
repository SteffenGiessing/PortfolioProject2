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

        public IList<Person_Info> GetActorsKnownFor()
        {
            using var ctx = new DatabaseConnection();
            IList<Person_Info> list = ctx.Person_Info.ToList();
            return list;
        }

        public async Task<List<Person_Known_For>> GetPersonKnownFor(string pid)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Person_Known_For
                .FromSqlRaw("SELECT * FROM person_known_for WHERE pid = {0}", pid)
                .ToListAsync();
        }
        
        public async Task<List<Person_Info>> GetActorOnPid(string pid)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Person_Info
                .FromSqlRaw("SELECT * FROM person_info WHERE pid = {0}", pid)
                .ToListAsync();
        }
    }
}