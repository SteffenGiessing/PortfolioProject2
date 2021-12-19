/*
 * Actor Interface.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.DMOs;

namespace WebApplication.DataInterfaces
{
    public interface IActorDataService
    {
        IList<Person_Info> GetAllActors();
        Task<List<Person_Known_For>> GetPersonKnownFor(string pid);
        Task<List<Person_Info>> GetActorOnPid(string pid);
        Task<List<Person_Info>> GetActorsByName(string name);
        Task<List<Person_Profession>> GetPersonProfessionByActorId(string pid);
        Task<List<NameSearch>> GetBestMatchPersonName(string searchName);
    }
}