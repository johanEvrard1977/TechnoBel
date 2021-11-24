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
    public interface IFiliereRepository : IRepository<int, Filiere>
    {
        Task<IEnumerable<Filiere>> Get(string Name, int annee, List<string> Names);
        Task<Filiere> GetOne(int id, string name);
        Task<bool> AlreadyExists(string name);
        Task<PagedList<Filiere>> GetFiliere(Parameters Parameters);
    }
}
