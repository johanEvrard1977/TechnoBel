using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Core.Interfaces;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.ViewModels;

namespace TechnoBel.Core.Repositories
{
    public class ParametreRepository : Repository<int, Parameters>, IParametreRepository
    {
        private readonly Context _context;
        public ParametreRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
