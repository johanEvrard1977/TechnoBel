using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Interfaces;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Models;

namespace TechnoBel.Core.Repositories
{
    public class ProjetCategorieRepository : Repository<int, Projet_Categorie>, IProjetCategorieRepository
    {
        private readonly Context _context;
        public ProjetCategorieRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Projet_Categorie> GetByProjetId(int projetId)
        {
            var request = from projets in _context.Projet_Categories select projets;


            return await request
                .Where(w => w.ProjetId == projetId)
                    .FirstAsync();
        }
    }
}
