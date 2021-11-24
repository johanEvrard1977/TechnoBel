using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface IFiliereImageRepository : IRepository<int, Filiere_Image>
    {
        Task<Filiere_Image> GetByFiliereId(int projetId);
    }
}
