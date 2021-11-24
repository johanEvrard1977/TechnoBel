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
    public class HobbyRepository : Repository<int, Hobbies>, IHobbyRepository
    {
        private readonly Context _context;
        public HobbyRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.Hobby.AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<Hobbies>> Get(string Name)
        {
            var request = from hobbies in _context.Hobby select hobbies;
            if (Name != null)
            {
                request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Profile)
                    .Where(w => w.Name.Contains(Name))
                    .OrderBy(w => w.Name);
            }
            else
            {
                request = request
                    .Include(w => w.Hobby_Profiles)
                    .ThenInclude(w => w.Profile)
                    .OrderBy(w => w.Name);
            }
            return await request.ToListAsync();
        }

        public async Task<PagedList<Hobbies>> GetHobbies(Parameters Parameters)
        {
            List<Hobbies> hobbies = await _context.Hobby.ToListAsync();
            return PagedList<Hobbies>
                .ToPagedList(hobbies, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}
