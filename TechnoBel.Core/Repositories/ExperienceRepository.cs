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
    public class ExperienceRepository : Repository<int, Experience>, IExperienceRepository
    {
        private readonly Context _context;
        public ExperienceRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Experiences.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Experience>> Get(string Titre)
        {
            var request = from titres in _context.Experiences select titres;
            if (Titre != null)
            {
                request = request
                    .Include(w => w.User)
                    .Where(w => w.Titre.Contains(Titre))
                    .OrderBy(w => w.Titre);
            }
            else
            {
                request = request
                    .Include(w => w.User)
                    .OrderBy(w => w.Titre);
            }
            return await request
                .ToListAsync();
        }

        public async Task<Experience> GetByName(string titre)
        {
            var request = from experiences in _context.Experiences select experiences;
            return await request
                .Include(w => w.User)
                    .OrderBy(w => w.Titre)
                    .FirstAsync();
        }

        public async Task<PagedList<Experience>> GetExperience(Parameters Parameters)
        {
            List<Experience> exp = await _context.Experiences.ToListAsync();
            return PagedList<Experience>
                .ToPagedList(exp, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}

