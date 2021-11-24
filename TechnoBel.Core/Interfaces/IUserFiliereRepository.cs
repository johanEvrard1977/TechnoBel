using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface IUserFiliereRepository : IRepository<int, UserFiliere>
    {
        Task<UserFiliere> GetByFiliereId(int filiereId);
    }
}
