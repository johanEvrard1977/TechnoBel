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
    public interface IStatutRepository : IRepository<int, Statut>
    {
        Task<IEnumerable<Statut>> Get(string Name);
        Task<bool> AlreadyExists(int id);
        Task<PagedList<Statut>> GetStatuts(Parameters Parameters);
    }
}
