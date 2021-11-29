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
        Task<List<Person_Known_For>> GetPersonKnownFor(string pid);
        Task<List<Person_Info>> GetActorOnPid(string pid);
        Task<List<Person_Info>> GetActorsByName(string name);
        Task<List<Person_Profession>> GetPersonProfessionByActorId(string pid);
        Task<List<NameSearch>> GetBestMatchPersonName(string searchName);
        Name_Bookmark GetNameBookmark(string userid, string titleid);
        IList<Name_Bookmark> GetNameBookmarks (string userid);
        Name_Bookmark CreateNameBookmark(string userid, string pid);

    }
}