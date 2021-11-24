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
    public class LangueRepository : Repository<int, Langue>, ILangueRepository
    {
        private readonly Context _context;
        public LangueRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Langues.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Langue>> Get(string Name)
        {
            var request = from langues in _context.Langues select langues;
            if (Name != null)
            {
                request = request
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .OrderBy(w => w.Name);
            }
            return await request.ToListAsync();
        }
    }
}