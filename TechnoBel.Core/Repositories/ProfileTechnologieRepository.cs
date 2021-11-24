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
    public class ProfileTechnologieRepository : Repository<int, ProfileTechnologie>, IProfileTechnologieRepository
    {
        private readonly Context _context;
        public ProfileTechnologieRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
