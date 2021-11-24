using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface ILangueRepository : IRepository<int, Langue>
    {
        Task<IEnumerable<Langue>> Get(string Name);
        Task<bool> AlreadyExists(int id);
    }
}
