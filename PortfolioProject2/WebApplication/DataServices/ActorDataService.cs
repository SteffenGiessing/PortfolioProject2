using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;
using IActorDataService = WebApplication.DataInterfaces.IActorDataService;

namespace WebApplication.DataServices
{
    public class ActorDataService : IActorDataService
    {
        public DatabaseConnection ctx { get; set; }

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

        public async Task<List<Person_Info>> GetActorsByName(string name)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Person_Info
                .Where(a => a.PrimaryName.Contains(name))
                .ToListAsync();
        }
        public async Task<List<Person_Profession>> GetPersonProfessionByActorId(string pid)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Person_Profession
                .FromSqlRaw("SELECT * FROM person_profession WHERE pid = {0}", pid)
                .ToListAsync();
        }

        public async Task<List<NameSearch>> GetBestMatchPersonName(string searchWord)
        {
            var ctx = new DatabaseConnection();
            return await ctx.NameSearches.FromSqlRaw("SELECT pid, primaryname from actor_search({0})", searchWord).ToListAsync();
        }
        
        //actorbookmarks------------------------------------------------------
        public Name_Bookmark GetNameBookmark(string userid, string pid)
        {
            return ctx.Name_Bookmark.Find(userid, pid);
        }
        public IList<Name_Bookmark> GetNameBookmarks(string userid)
        {
            IList<Name_Bookmark> result = new List<Name_Bookmark>();
            using var ctx = new DatabaseConnection();
            
            foreach (var bk in ctx.Name_Bookmark)
            {
                if (bk.UserId.Trim() == userid)
                {
                    result.Add(bk);
                }
            }
            return result;
        }
        
        public Name_Bookmark CreateNameBookmark(string userid, string pid)
        {
            using var ctx = new DatabaseConnection();
            var result = new Name_Bookmark()
            {
                UserId = userid,
                Pid = pid,
                BookMarkTime = DateTime.Now
            };
            ctx.Name_Bookmark.Add(result);
            ctx.SaveChanges();
            return result;
        }
        
        
    }
}