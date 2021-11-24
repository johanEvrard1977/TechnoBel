using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface IUserProjetRepository : IRepository<int, UserProjet>
    {
        Task<UserProjet> GetByProjetId(int projetId);
    }
}
