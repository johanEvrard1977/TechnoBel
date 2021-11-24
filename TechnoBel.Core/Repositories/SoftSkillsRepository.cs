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
    public class SoftSkillsRepository : Repository<int, SoftSkills>, ISoftSkillsRepository
    {
        private readonly Context _context;
        public SoftSkillsRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(int id)
        {
            if (await _context.SoftSkills
                    .AnyAsync(e => e.Id == id))
                return true;
            return false;
        }

        public async Task<IEnumerable<SoftSkills>> Get(string Name = null)
        {
            var request = from softSkills in _context.SoftSkills select softSkills;
            if (Name != null)
            {
                request = request
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.SoftSkill)
                    .Include(e => e.UserSoftSkills)
                    .ThenInclude(e => e.User)
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

        public async Task<PagedList<SoftSkills>> GetSoftSkills(Parameters Parameters)
        {
            List<SoftSkills> hobbies = await _context.SoftSkills.ToListAsync();
            return PagedList<SoftSkills>
                .ToPagedList(hobbies, Parameters.PageNumber, Parameters.PageSize);
        }
    }
}