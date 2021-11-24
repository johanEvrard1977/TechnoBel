using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Interfaces;
using TechnoBel.Core.Paging;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Models;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Core.Repositories
{
    public class CategorieDeProjetRepository : Repository<int, CategorieDeProjet>, ICategorieDeProjetRepository
    {
        private readonly Context _context;
        public CategorieDeProjetRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.CategorieDeProjets.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<CategorieDeProjet>> Get(string Name)
        {
            var request = from filieres in _context.CategorieDeProjets select filieres;
            if (Name != null)
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .OrderBy(w => w.Name);
            }
            return await request
                .ToListAsync();
        }

        public async Task<CategorieDeProjet> GetByName(string name)
        {
            var request = from filieres in _context.CategorieDeProjets select filieres;
            return await request
                .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .OrderBy(w => w.Name)
                    .FirstAsync();
        }

        public async Task<PagedList<CategorieDeProjet>> GetCategorieDeProjet(Parameters Parameters)
        {
            List<CategorieDeProjet> filieres = await _context.CategorieDeProjets.ToListAsync();
            return PagedList<CategorieDeProjet>
                .ToPagedList(filieres, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}
