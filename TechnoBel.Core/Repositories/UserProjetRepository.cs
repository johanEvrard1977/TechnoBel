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
    public class UserProjetRepository : Repository<int, UserProjet>, IUserProjetRepository
    {
        private readonly Context _context;
        public UserProjetRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<UserProjet> GetByProjetId(int projetId)
        {
            var request = from projets in _context.UserProjets select projets;
            
            
            return await request
                .Where(w => w.ProjetId == projetId)
                    .FirstAsync();
        }
    }
}
