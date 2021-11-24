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
    public interface IProjetRepository : IRepository<int, Projet>
    {
        Task<IEnumerable<Projet>> Get(string UserName, string Name, DateTime debut, DateTime Fin, List<string> Sujets, List<string> Names);
        Task<Projet> GetOne(int id, string name);
        Task<Projet> GetByStagiaireId(int stagiaireId);
        Task<bool> AlreadyExists(string name);
        Task<PagedList<Projet>> GetProjets(Parameters Parameters);
    }
}
