/*
 * Actor Dataservice this is where we will execute our commands towards the database regarding actors.
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataInterfaces;
using WebApplication.DMOs;

namespace WebApplication.DataServices
{
    public class ActorDataService : IActorDataService
    {
        
        /*
         * Get All Actors.
         */
        public IList<Person_Info> GetAllActors()
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            IList<Person_Info> list = ctx.Person_Info.ToList();
            return list;
        }

        public IList<Person_Info> GetActorsKnownFor()
        {
            using var ctx = new DatabaseConnection.DatabaseConnection();
            IList<Person_Info> list = ctx.Person_Info.ToList();
            return list;
        }
        /*
         * Getting what a actor is known for.
         */
        public async Task<List<Person_Known_For>> GetPersonKnownFor(string pid)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Person_Known_For
                .FromSqlRaw("SELECT * FROM person_known_for WHERE pid = {0}", pid)
                .ToListAsync();
        }
        /*
         * Getting actor based on a specific id.
         */
        public async Task<List<Person_Info>> GetActorOnPid(string pid)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Person_Info
                .FromSqlRaw("SELECT * FROM person_info WHERE pid = {0}", pid)
                .ToListAsync();
        }
        /*
         * Get all actors matching a user defined name.
         */
        public async Task<List<Person_Info>> GetActorsByName(string name)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Person_Info
                .Where(a => a.PrimaryName.Contains(name))
                .ToListAsync();
        }
        /*
         * Getting a person profession based on a id.
         */
        public async Task<List<Person_Profession>> GetPersonProfessionByActorId(string pid)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.Person_Profession
                .FromSqlRaw("SELECT * FROM person_profession WHERE pid = {0}", pid)
                .ToListAsync();
        }
        /*
         * Getting the best possible match on a persons name.
         */
        public async Task<List<NameSearch>> GetBestMatchPersonName(string searchWord)
        {
            var ctx = new DatabaseConnection.DatabaseConnection();
            return await ctx.NameSearches.FromSqlRaw("SELECT pid, primaryname, role from actor_search({0})", searchWord)
                .ToListAsync();
        }
    }
}