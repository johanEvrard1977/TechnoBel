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
    public class StatutRepository : Repository<int, Statut>, IStatutRepository
    {
        private readonly Context _context;
        public StatutRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Statut.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Statut>> Get(string Name)
        {
            var request = from contacts in _context.Statut select contacts;
            if (Name != null)
            {
                request = request
                    .Include(w => w.Profiles)
                    .ThenInclude(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.Profiles)
                    .ThenInclude(w => w.User)
                    .Include(w => w.Profiles)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.Profiles)
                    .ThenInclude(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Hobbies)
                    .Include(w => w.Profiles)
                    .ThenInclude(w => w.User)
                    .Include(w => w.Profiles)
                    .OrderBy(w => w.Name);
            }
            return await request.ToListAsync();
        }

        public async Task<PagedList<Statut>> GetStatuts(Parameters Parameters)
        {
            List<Statut> statuts = await _context.Statut.ToListAsync();
            return PagedList<Statut>
                .ToPagedList(statuts, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}
