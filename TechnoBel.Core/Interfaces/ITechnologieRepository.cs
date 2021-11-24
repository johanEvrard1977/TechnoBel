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
    public interface ITechnologieRepository : IRepository<int, Technologie>
    {
        Task<IEnumerable<Technologie>> Get(string Name);
        Task<PagedList<Technologie>> GetTechnologie(Parameters Parameters);
        Task<bool> AlreadyExists(int id);
    }
}
