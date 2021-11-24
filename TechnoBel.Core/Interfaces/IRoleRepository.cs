using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface IRoleRepository : IRepository<int, Role>
    {
        Task<IEnumerable<Role>> Get(string Name);
        Task<bool> AlreadyExists(string id);
    }
}
