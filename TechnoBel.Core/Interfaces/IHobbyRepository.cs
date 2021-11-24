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
    public interface IHobbyRepository : IRepository<int, Hobbies>
    {
        Task<IEnumerable<Hobbies>> Get(string Name);
        Task<bool> AlreadyExists(int id);
        Task<PagedList<Hobbies>> GetHobbies(Parameters Parameters);
    }
}
