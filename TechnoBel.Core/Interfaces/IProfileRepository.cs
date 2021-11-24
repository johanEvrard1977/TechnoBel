using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Core.Interfaces
{
    public interface IProfileRepository : IRepository<int, Profile>
    {
        Task<IEnumerable<Profile>> Get(string Name, string FirstName, string email, List<string> Names = null);
        Task<Profile> GetByUserId(int userId);
        Task<bool> AlreadyExists(int id);
        Task<PagedList<Profile>> GetProfiles(Parameters Parameters);
    }
}
