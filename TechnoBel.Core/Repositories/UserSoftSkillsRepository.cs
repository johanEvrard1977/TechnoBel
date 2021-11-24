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
    public class UserSoftSkillsRepository : Repository<int, UserSoftSkills>, IUserSoftSkillsRepository
    {
        private readonly Context _context;
        public UserSoftSkillsRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<UserSoftSkills> GetBySoftSkillsId(int softSkillsId)
        {
            var request = from filieres in _context.UserSoftSkills select filieres;


            return await request
                .Where(w => w.SoftSkillsId == softSkillsId)
                    .FirstAsync();
        }
    }
}