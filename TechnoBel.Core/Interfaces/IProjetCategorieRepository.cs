using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Interfaces
{
    public interface IProjetCategorieRepository : IRepository<int, Projet_Categorie>
    {
        Task<Projet_Categorie> GetByProjetId(int projetId);
    }
}
