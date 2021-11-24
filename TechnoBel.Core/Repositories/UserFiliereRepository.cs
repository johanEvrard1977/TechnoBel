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
    public class UserFiliereRepository : Repository<int, UserFiliere>, IUserFiliereRepository
    {
        private readonly Context _context;
        public UserFiliereRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<UserFiliere> GetByFiliereId(int filiereId)
        {
            var request = from filieres in _context.UserFilieres select filieres;


            return await request
                .Where(w => w.FiliereId == filiereId)
                    .FirstAsync();
        }
    }
}
