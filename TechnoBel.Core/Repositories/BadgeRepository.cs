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
    public class BadgeRepository : Repository<int, Badge>, IBadgeRepository
    {
        private readonly Context _context;
        public BadgeRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Filieres.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Badge>> Get(string Name)
        {
            var request = from badges in _context.Badges select badges;
            if (Name != null)
            {
                request = request
                    .Include(w => w.UserBadges)
                    .ThenInclude(w => w.User)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.UserBadges)
                    .ThenInclude(w => w.User)
                    .OrderBy(w => w.Name);
            }
            return await request
                .ToListAsync();
        }

        public async Task<Badge> GetByName(string name)
        {
            var request = from filieres in _context.Badges select filieres;
            return await request
                .Include(w => w.UserBadges)
                    .ThenInclude(w => w.User)
                    .OrderBy(w => w.Name)
                    .FirstAsync();
        }

        public async Task<PagedList<Badge>> GetBadge(Parameters Parameters)
        {
            List<Badge> filieres = await _context.Badges.ToListAsync();
            return PagedList<Badge>
                .ToPagedList(filieres, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}

