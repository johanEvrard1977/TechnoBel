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
    public class RoleRepository : Repository<int, Role>, IRoleRepository
    {
        private readonly Context _context;
        public RoleRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(string id)
        {
            if (await _context.Role.AnyAsync(e => e.Id.Equals(id)))
                return true;
            return false;
        }

        public async Task<IEnumerable<Role>> Get(string Name)
        {
            var request = from roles in _context.Role select roles;
            if (Name != null)
            {
                request = request
                    .Include(w => w.UserRoles)
                    .ThenInclude(w => w.User)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.UserRoles)
                    .ThenInclude(w => w.User)
                    .OrderBy(w => w.Name);
            }
            return await request.ToListAsync();
        }
    }
}
