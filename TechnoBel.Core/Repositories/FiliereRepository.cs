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
    public class FiliereRepository : Repository<int, Filiere>, IFiliereRepository
    {
        private readonly Context _context;
        public FiliereRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(string name)
        {
            if (await _context.Filieres.AnyAsync(e => e.Name == name))
                return true;
            return false;
        }

        public async Task<IEnumerable<Filiere>> Get(string Name = null, int Annee = 0, List<string> Names = null)
        {
            var request = from filieres in _context.Filieres select filieres;
            if (Name != null && Annee == 0)
            {
                request = request
                    .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.Filiere_Images)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else if (Annee != 0 && Name == null)
            {
                request = request
                    .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.Filiere_Images)
                    .Where(w => w.Annee == Annee)
                    .OrderBy(w => w.Name);
            }
            else if (Annee != 0 && Name != null)
            {
                request = request
                    .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.Filiere_Images)
                    .Where(w => w.Annee == Annee)
                    .Where(w => w.Name.Equals(Name))
                    .OrderBy(w => w.Name);
            }
            else if (Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                return _context.FiliereTechonologies.Include(ft => ft.Filiere).Include(ft => ft.Technologie)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Filiere);
            }
            else if ( Name != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                request = _context.FiliereTechonologies.Include(ft => ft.Filiere).Include(ft => ft.Technologie)
                    .Where(ft => ft.Filiere.Name.Contains(Name))
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Filiere);
                return request;
            }
            else if (Annee != 0 && Name != null && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

                return _context.FiliereTechonologies.Include(ft => ft.Filiere).Include(ft => ft.Technologie)
                    .Where(ft => ft.Filiere.Name.Contains(Name))
                    .Where(ft => ft.Filiere.Annee == Annee)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Filiere);
            }
            else if (Annee != 0 && Names != null && Names[0] != null)
            {
                IEnumerable<string> keywords = Names[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

                return _context.FiliereTechonologies.Include(ft => ft.Filiere).Include(ft => ft.Technologie)
                    .Where(ft => ft.Filiere.Annee == Annee)
                    .Where(ft => Names.Select(n => n.ToLower()).Contains(ft.Technologie.Name.ToLower()))
                    .Select(ft => ft.Filiere);
            }
            else
            {
                request = request
                    .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.Filiere_Images)
                    .OrderBy(w => w.Name);
            }
            return await request
                .ToListAsync();
        }

        public async Task<Filiere> GetByName(string name)
        {
            var request = from filieres in _context.Filieres select filieres;
            return await request
                .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Filiere)
                    .Include(w => w.Filiere_Images)
                    .OrderBy(w => w.Name)
                    .FirstAsync();
        }

        public async Task<PagedList<Filiere>> GetFiliere(Parameters Parameters)
        {
            List<Filiere> filieres = await _context.Filieres
                .Include(w => w.Filiere_Images)
                .ToListAsync();

            return PagedList<Filiere>
                .ToPagedList(filieres, Parameters.PageNumber, Parameters.PageSize);
        }

        public async Task<Filiere> GetOne(int id, string name)
        {
            var request = from projets in _context.Filieres select projets;
            if (name != null)
            {
                request = request
                    .Include(w => w.Filiere_Images)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Where(w => w.Name.Equals(name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.Filiere_Images)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.UserFiliere)
                    .ThenInclude(w => w.User)
                    .Where(w => w.Id == id)
                    .OrderBy(w => w.Name);
            }
            return await request
                    .FirstAsync();
        }
    }
}

