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
    public interface ICategorieDeProjetRepository : IRepository<int, CategorieDeProjet>
    {
        Task<IEnumerable<CategorieDeProjet>> Get(string Name);
        Task<bool> AlreadyExists(int id);
        Task<PagedList<CategorieDeProjet>> GetCategorieDeProjet(Parameters Parameters);
    }
}
