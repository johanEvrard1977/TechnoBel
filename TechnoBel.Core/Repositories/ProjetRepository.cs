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
    public class ProjetRepository : Repository<int, Projet>, IProjetRepository
    {
        private readonly Context _context;
        public ProjetRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(string name)
        {
            if (await _context.Projets.AnyAsync(e => e.Name == name))
                return true;
            return false;
        }

        public async Task<IEnumerable<Projet>> Get(string UserName, string Name, DateTime debut, DateTime Fin, List<string> Sujets, List<string> Names)
        {
            var request = from projets in _context.Projets select projets;
            if (Name != null)
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Include(w => w.UserProjet)
                    .ThenInclude(w => w.User)
                    .Include(w => w.ProjetImages)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    //.ThenInclude(w => w.Image)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else if (UserName != null)
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Include(w => w.UserProjet)
                    .ThenInclude(w => w.User)
                    .Include(w => w.ProjetImages)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    //.ThenInclude(w => w.Image)
                    .Where(w => w.UserProjet.FirstOrDefault().User.UserName.Contains(UserName))
                    .OrderBy(w => w.Name);
            }
            else if (Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                return _context.Projet_Technologies.Include(ft => ft.Projet).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Projet);
            }
            else if ( Name != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

                return _context.Projet_Technologies.Include(ft => ft.Projet).Include(ft => ft.Technologie)
                    .Where(p => p.Projet.Name.Contains(Name))
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Projet);
            }
            else
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Include(w => w.UserProjet)
                    .ThenInclude(w => w.User)
                    .Include(w => w.ProjetImages)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .OrderBy(w => w.Name);
            }
            return await request
                .ToListAsync();
        }

        public async Task<Projet> GetByStagiaireId(int stagiaireId)
        {
            var request = from projets in _context.Projets select projets;
            request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Include(w => w.UserProjet)
                    .ThenInclude(w => w.User)
                    .Include(w => w.ProjetImages)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .Where(w => w.UserProjet.FirstOrDefault().StagiaireId == stagiaireId)
                    .OrderBy(w => w.Name);
            return await request
                    .FirstAsync();
        }

        public async Task<Projet> GetOne(int id, string name)
        {
            var request = from projets in _context.Projets select projets;
            if(name != null)
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Include(w => w.UserProjet)
                    .ThenInclude(w => w.User)
                    .Include(w => w.ProjetImages)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .Where(w => w.Name.Equals(name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Projet)
                    .Include(w => w.Projet_categories)
                    .ThenInclude(w => w.Categorie)
                    .Include(w => w.UserProjet)
                    .ThenInclude(w => w.User)
                    .Include(w => w.ProjetImages)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .Where(w => w.Id == id)
                    .OrderBy(w => w.Name);
            }
            return await request
                    .FirstAsync();
        }

        public async Task<PagedList<Projet>> GetProjets(Parameters Parameters)
        {
            List<Projet> filieres = await _context.Projets
                .Include(w => w.ProjetImages)
                .ToListAsync();

            return PagedList<Projet>
                .ToPagedList(filieres, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}
