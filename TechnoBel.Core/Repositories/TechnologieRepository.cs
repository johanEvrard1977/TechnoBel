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
    public class TechnologieRepository : Repository<int, Technologie>, ITechnologieRepository
    {
        private readonly Context _context;
        public TechnologieRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Technologie
                    .Include(w => w.UserTechnologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.UserTechnologies)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Filiere)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Technologie>> Get(string Name = null)
        {
            var request = from hobbies in _context.Technologie select hobbies;
            if (Name != null)
            {
                request = request
                    .Include(w => w.UserTechnologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.UserTechnologies)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Filiere)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.UserTechnologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.UserTechnologies)
                    .ThenInclude(w => w.User)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Technologie)
                    .Include(w => w.FiliereTechonologies)
                    .ThenInclude(w => w.Filiere)
                    .Include(w => w.Projet_Technologies)
                    .ThenInclude(w => w.Technologie)
                    .OrderBy(w => w.Name);
            }
            return await request.ToListAsync();
        }

        public async Task<PagedList<Technologie>> GetTechnologie(Parameters Parameters)
        {
            List<Technologie> hobbies = await _context.Technologie.ToListAsync();
            return PagedList<Technologie>
                .ToPagedList(hobbies, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}
